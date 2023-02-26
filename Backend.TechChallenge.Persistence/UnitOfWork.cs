using Backend.TechChallenge.Domain.Contracts;

namespace Backend.TechChallenge.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEnumerable<IRepository> _repositories;

        public UnitOfWork(IUsersRepository usersRepository)
        {
            UsersRepository = usersRepository;
            _repositories = new IRepository[] { usersRepository };
        }

        public IUsersRepository UsersRepository { get; private set; }

        public async Task Rollback() => 
            await Task.WhenAll(_repositories.Select(repository => repository.Rollback()));

        public async Task SaveChanges() => 
            await Task.WhenAll(_repositories.Select(repository => repository.SaveChanges()));
    }
}
