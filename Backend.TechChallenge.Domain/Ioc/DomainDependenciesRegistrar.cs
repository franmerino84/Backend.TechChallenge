using Backend.TechChallenge.Domain.Services.Email;
using Backend.TechChallenge.Domain.Services.Users;
using Backend.TechChallenge.Domain.Services.Users.Creation;
using Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters;
using Backend.TechChallenge.Domain.Services.Users.Creation.Email;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.TechChallenge.Domain.Ioc
{
    public static class DomainDependenciesRegistrar
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IUsersFactory, UsersFactory>();
            services.AddSingleton<INewUsersFactory, NewUsersFactory>();
            services.AddSingleton<IEmailNormalizer, EmailNormalizer>();
            services.AddSingleton<IEmailNormalizerUserCreationDecorator, EmailNormalizerUserCreationDecorator>();
            services.AddSingleton<IUserCreationDecoratorFactory, EmailNormalizerUserCreationDecoratorFactory>();
            services.AddSingleton<IUserCreationDecoratorFactory, UserCreationGifterFactory>();
            return services;
        }
    }
}
