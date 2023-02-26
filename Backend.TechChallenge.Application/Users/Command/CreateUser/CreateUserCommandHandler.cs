using AutoMapper;
using Backend.TechChallenge.Domain.Contracts;
using Backend.TechChallenge.Domain.Services.Users.Creation;
using Backend.TechChallenge.Persistence.File.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.TechChallenge.Application.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly INewUsersFactory _userFactory;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(INewUsersFactory userFactory, IMapper mapper, IUnitOfWork unitOfWork, ILogger<CreateUserCommandHandler> logger)
        {
            _userFactory = userFactory;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userFactory.CreateNewUser(request.Name, request.Email, request.Address, request.Phone, _mapper.Map<Domain.Entities.Users.UserType>(request.UserType), request.Money);

                await _unitOfWork.UsersRepository.Insert(user);
                await _unitOfWork.SaveChanges();
                _logger.LogInformation("New user created: '{Name}'.", request.Name);

                var response = _mapper.Map<CreateUserCommandResponse>(user);
                response.Status = CreateUserCommandResponseResult.Created;

                return response;
            }
            catch (DatabaseEntityDuplicatedException)
            {
                _logger.LogDebug("Failed user creation because it already exists: '{Name}'.", request.Name);
                return new CreateUserCommandResponse { Status = CreateUserCommandResponseResult.Duplicated };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed user creation because of unhandled exception: '{Name}'.",request.Name);
                return new CreateUserCommandResponse { Status = CreateUserCommandResponseResult.UnhandledError };
            }
        }
    }
}
