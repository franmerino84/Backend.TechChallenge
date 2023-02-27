using Backend.TechChallenge.Domain.Services.Email;
using Backend.TechChallenge.Domain.Services.Users;
using Backend.TechChallenge.Domain.Services.Users.Creation;
using Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters;
using Backend.TechChallenge.Domain.Services.Users.Creation.Email;
using Backend.TechChallenge.Domain.Services.Users.Creation.Gifters;
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
            services.AddSingleton<IUserCreationGifter, NormalUserCreationGifter>();
            services.AddSingleton<IUserCreationGifter, SuperUserCreationGifter>();
            services.AddSingleton<IUserCreationGifter, PremiumUserCreationGifter>();
            services.AddSingleton<IEmailNormalizerUserCreationModifier, EmailNormalizerUserCreationModifier>();
            services.AddSingleton<IUserCreationModifierProvider, EmailNormalizerUserCreationModifierProvider>();
            services.AddSingleton<IUserCreationModifierProvider, UserCreationGifterModifierProvider>();
            
            return services;
        }
    }
}
