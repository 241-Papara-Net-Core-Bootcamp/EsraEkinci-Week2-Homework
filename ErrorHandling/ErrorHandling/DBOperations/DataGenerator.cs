using ErrorHandling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ErrorHandling.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.Users.AddRange(
                    new User
                    {                        
                        UserName = "Esra",
                        UserSurname = "Ekinci",
                        UserGender = "Female",
                        RegisteredDate = new DateTime(2022, 11, 05)
                    },
                    new User
                    {                        
                        UserName = "Baki",
                        UserSurname = "Koruk",
                        UserGender = "Male",
                        RegisteredDate = new DateTime(2022, 09, 03)
                    },
                    new User
                    {                        
                        UserName = "Sinem",
                        UserSurname = "Dag",
                        UserGender = "Female",
                        RegisteredDate = new DateTime(2022, 05, 01)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
