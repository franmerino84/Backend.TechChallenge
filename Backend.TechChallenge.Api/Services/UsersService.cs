using Backend.TechChallenge.Api.Domain.Users;
using Backend.TechChallenge.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.TechChallenge.Api.Services
{
    public class UsersService
    {
        private readonly List<User> _users = new List<User>();

        public void Create(User newUser)
        {
            //TODO this part has to be adjusted somehow based on the class
            if (newUser.UserType == "Normal")
            {
                if (newUser.Money > 100)
                {
                    var gift = newUser.Money * 0.12m;
                    newUser.Money += gift;
                }
                else if (newUser.Money < 100 && newUser.Money > 10)
                {
                    var gift = newUser.Money * 0.8m;
                    newUser.Money += gift;
                }
            }
            if (newUser.UserType == "SuperUser" && newUser.Money > 100)
            {
                var gift = newUser.Money * 0.2m;
                newUser.Money += gift;
            }

            if (newUser.UserType == "Premium" && newUser.Money > 100)
            {
                var gift = newUser.Money * 2;
                newUser.Money += gift;
            }

            //TODO all this read, check and writes has to be done at persistence layer
            var reader = ReadUsersFromFile();

            //Normalize email
            var aux = newUser.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            newUser.Email = $"{aux[0]}@{aux[1]}";

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;

                // TODO: Here I put NormalUser instead of the previous generic User
                var user = new NormalUser
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();

            foreach (var user in _users)
            {
                if (user.Email == newUser.Email
                    || user.Phone == newUser.Phone
                    || user.Name == newUser.Name
                        && user.Address == newUser.Address)
                    throw new UserDuplicatedException();

            }

            WriteUserToFile(newUser);
        }
        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        private void WriteUserToFile(User user)
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            using StreamWriter outputFile = new StreamWriter(path, append: true);

            outputFile.WriteLine(user.Name + "," + user.Email + "," + user.Phone + "," + user.Address + "," + user.UserType + "," + user.Money);
        }

    }
}
