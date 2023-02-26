using Backend.TechChallenge.Domain.Contracts;
using Moq;
using System.Runtime.CompilerServices;
using Xunit;

namespace Backend.TechChallenge.Persistence.File.Test
{
    public class UnitOfWorkUnitTests
    {
        private readonly Mock<IUsersRepository> _usersRepository;
        private readonly UnitOfWork _unitOfWork;

        public UnitOfWorkUnitTests()
        {
            _usersRepository = new Mock<IUsersRepository>();
            _unitOfWork = new UnitOfWork(_usersRepository.Object);
        }

        [Fact]
        public async Task SaveChanges_CallsUsersRepositorySaveChanges()
        {
            await _unitOfWork.SaveChanges();

            _usersRepository.Verify(x=>x.SaveChanges());
        }

        [Fact]
        public async Task Rollback_CallsUsersRepositoryRollback()
        {
            await _unitOfWork.Rollback();

            _usersRepository.Verify(x => x.Rollback());
        }

        [Fact]
        public void UsersRepository_ReturnInjectedOne()
        {
            Assert.Equal(_usersRepository.Object, _unitOfWork.UsersRepository);
        }
    }
}
