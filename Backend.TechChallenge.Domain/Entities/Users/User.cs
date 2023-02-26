namespace Backend.TechChallenge.Domain.Entities.Users
{
    public abstract class User
    {
        protected User(string name, string email, string address, string phone, decimal money)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            Money = money;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }        
        public decimal Money { get; set; }               
        public abstract UserType GetUserType();
        public string GetUserTypeAsString() => 
            GetUserType().ToString();

    }
}
