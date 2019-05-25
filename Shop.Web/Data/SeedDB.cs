

namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly UserManager<User> userManager;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("aticristian@hotmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Cristian",
                    LastName = "Tisoy",
                    Email = "aticristian@hotmail.com",
                    UserName = "aticristian@hotmail.com",
                    PhoneNumber = "3118787376"
                };

                var result = await this.userHelper.AddUserAsync(user, "1234");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }






                if (!this.context.Products.Any())
                {
                    this.AddProduct("Portatil Azus", user);
                    this.AddProduct("Teclado Gamer", user);
                    this.AddProduct("Celular Nokia", user);
                    await this.context.SaveChangesAsync();
                }
            }
        }

        private void AddProduct(string name, User user)
        {
                this.context.Products.Add(new Product
                {
                    Name = name,
                    Price = this.random.Next(1000),
                    IsAvailabe = true,
                    Stock = this.random.Next(100),
                    User = user
            });
        }
    }

}
