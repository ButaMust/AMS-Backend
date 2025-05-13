using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using Domain;

namespace Persistance
{
    public class DbInitializer
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            if (context.Users.Any()) return;

            var users = new List<User>
            {
                new User
                {
                    Name = "Butrint",
                    LastName = "Mustafa",
                    Email = "butrintmustafa154@gmail.com",
                    Password = "Butrint123",
                    Role = "Admin",
                },

                new User
                {
                    Name = "Leuron",
                    LastName = "Ilazi",
                    Email = "leuronilazi@gmail.com",
                    Password = "Leuron123",
                    Role = "Banore",
                }
            };

            context.Users.AddRange(users);

            await context.SaveChangesAsync();
        }
    }
}