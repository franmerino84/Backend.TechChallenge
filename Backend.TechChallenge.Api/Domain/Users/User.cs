namespace Backend.TechChallenge.Api.Domain.Users
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        //TODO UserType has to be removed
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}
