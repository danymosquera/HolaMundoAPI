using HolaMundoAPI.Data.Enumerations;
using HolaMundoAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HolaMundoAPI.Data
{
    public class SeedDb
    {
        private readonly DBContext context;
        private readonly Random random;

        public SeedDb(DBContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Client.Any())
            {
                this.AddClient("First Client");
                this.AddClient("Second Client");
                this.AddClient("Third Client");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.UserRoles.Any())
            {
                this.AddUserRole("Administrator", RoleType.SuperAdmin);
                this.AddUserRole("Staff", RoleType.Staff);
                this.AddUserRole("Guest", RoleType.Guest);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Users.Any())
            {
                this.AddUser("Admin", "123", 1);
                this.AddUser("pepito", "123", 2);
                this.AddUser("user", "123", 3);
                await this.context.SaveChangesAsync();
            }

            var user = this.CheckUser(1);

            if (!this.context.Products.Any())
            {
                this.AddProduct("Blue", 20000, user);
                this.AddProduct("Yellow ", 15000, user);
                this.AddProduct("Black", 22000, user);
                this.AddProduct("Red", 16000, user);
                this.AddProduct("Green", 20000, user);
                this.AddProduct("Orange", 12000, user);
                this.AddProduct("Purple ", 21000, user);
                this.AddProduct("Brown", 23000, user);
                this.AddProduct("White ", 23000, user);
                this.AddProduct("Grey ", 19000, user);
                await this.context.SaveChangesAsync();
            }

            await this.context.Database.MigrateAsync();

        }

        private User CheckUser(long userId)
        {
            // Add user
            var user = this.context.Users.Find(userId);
            return user;
        }

        private void AddClient(string name)
        {
            this.context.Client.Add(new Models.Client
            {
                Name = name,
                Dna = this.random.Next(1000000, 1999999).ToString()
            });
        }

        private void AddUserRole(string roleName, RoleType roleType)
        {
            this.context.UserRoles.Add(new Models.UserRole
            {
                Name = roleName,
                Type = roleType
            });
        }

        private void AddUser(string userId, string password, long userRoleId)
        {
            this.context.Users.Add(new Models.User
            {
                UserName = userId,
                Password = password,
                RoleId = userRoleId
            });
        }

        private void AddProduct(string name, decimal price, User user)
        {
            this.context.Products.Add(new Models.Product
            {
                Name = name,
                Price = price,
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user,
                ImageUrl = $"~/images/Products/{name}.png"
            });
        }

    }
}
