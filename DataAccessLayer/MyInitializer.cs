using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MyInitializer: CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            int id = 0;

            User admin = new User()
            {
                Id = id++,
                Name = "Ezgi",
                Surname = "CANDIR",
                Username = "ec",
                Password = "12345",
                Email = "ec@gmail.com",
                IsAdmin = true
            };

            context.Users.Add(admin);

            for (int i = 0; i < 10; i++)
            {
                User user = new User()
                {
                    Id = id++,
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Username = $"user{i}",
                    Password = $"user{i}",
                    Email = FakeData.NetworkData.GetEmail(),
                    IsAdmin = false
                };
                context.Users.Add(user);
            }

            context.SaveChanges();

        }
    }
}
