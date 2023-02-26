namespace Backend.TechChallenge.Application.Users.Command.CreateUser
{
    public enum CreateUserCommandResponseResult
    {
        Created,
        Duplicated,
        UnhandledError
    }
}