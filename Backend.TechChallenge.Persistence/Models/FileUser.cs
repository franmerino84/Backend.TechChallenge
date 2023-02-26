namespace Backend.TechChallenge.Persistence.File.Models
{
    public class FileUser
    {
        public FileUser() { }

        public FileUser(string databaseLine)
        {
            var splits = databaseLine.Split(',');

            Name = splits[0];
            Email = splits[1];
            Phone = splits[2];
            Address = splits[3];
            UserType = splits[4];
            Money = decimal.Parse(splits[5]);
        }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public decimal Money { get; set; }

        public string ToDatabaseLine() => 
            $"{Name},{Email},{Phone},{Address},{UserType},{Money}";
    }
}