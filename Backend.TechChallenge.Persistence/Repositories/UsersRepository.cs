using AutoMapper;
using Backend.TechChallenge.Domain.Contracts;
using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Persistence.File.Exceptions;
using Backend.TechChallenge.Persistence.File.Models;

namespace Backend.TechChallenge.Persistence.File.Repositories
{
    public class UsersRepository : IUsersRepository
    {        
        private readonly string _databasePath = @$"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\Files\Users.txt";
        private readonly IMapper _mapper;
        private readonly List<FileUser> _usersToAdd;


        public UsersRepository(IMapper mapper)
        {
            _usersToAdd = new List<FileUser>();
            _mapper = mapper;
        }

        private async Task<IEnumerable<FileUser>> InternalGetAll()
        {
            using FileStream fileStream = new(_databasePath, FileMode.Open);
            using StreamReader reader = new(fileStream);

            List<FileUser> users = new();

            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
                users.Add(new FileUser(line));

            return users;
        }

        public async Task Insert(User entity)
        {
            var fileUser = _mapper.Map<FileUser>(entity);

            var users = await InternalGetAll();

            if (IsDuplicated(fileUser, users))
                throw new DatabaseEntityDuplicatedException();

            _usersToAdd.Add(fileUser);
        }

        private static bool IsDuplicated(FileUser newUser, IEnumerable<FileUser> users) =>
            users.Any(user =>
              user.Email == newUser.Email
              || user.Phone == newUser.Phone
              || user.Name == newUser.Name
                  && user.Address == newUser.Address);

        public Task Rollback()
        {
            _usersToAdd.Clear();

            return Task.CompletedTask;
        }

        public async Task SaveChanges()
        {
            using StreamWriter outputFile = new(_databasePath, append: true);

            await Task.WhenAll(
                _usersToAdd.Select(user =>
                    outputFile.WriteLineAsync(user.ToDatabaseLine())));

            _usersToAdd.Clear();
        }
    }
}
