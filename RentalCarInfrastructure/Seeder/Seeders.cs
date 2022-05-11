using Microsoft.AspNetCore.Identity;
using RentalCarInfrastructure.Context;
using RentalCarInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Seeder
{
    public class Seeders
    {
        public enum UserRoles
        {
            Admin = 1,
            Dealer = 2,
            Customer = 3,
        }
        public class Seeder
        {
            public async static Task Seed(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, AppDbContext dbContext)
            {
                await dbContext.Database.EnsureCreatedAsync();

                await CreateUserRolesAsync(roleManager);
                await SeedUser(userManager, dbContext);
                await SeedDealers(userManager, dbContext);
            }

            private static async Task CreateUserRolesAsync(RoleManager<IdentityRole> roleManager)
            {
                var userRoles = new List<IdentityRole>
            {
                new IdentityRole(UserRoles.Admin.ToString()),
                new IdentityRole(UserRoles.Dealer.ToString()),
                new IdentityRole(UserRoles.Customer.ToString()),
            };
                if (!roleManager.Roles.Any())
                {
                    foreach (IdentityRole role in userRoles)
                    {
                        var result = await roleManager.CreateAsync(role);
                    }
                }
            }

            private static async Task SeedUser(UserManager<User> userManager, AppDbContext dbContext)
            {
                if (!dbContext.Users.Any())
                {
                    var users = SeederHelper<User>.GetData("User.json");
                    int count = 1;
                    foreach (var user in users)
                    {
                        if(count == 1)
                        {
                            user.EmailConfirmed = true;
                            var result = await userManager.CreateAsync(user, "Ja@12");
                            if (result.Succeeded)
                            {
                                await userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
                            }
                        }
                        else if(count < 6)
                        {
                            user.EmailConfirmed = true;
                            await userManager.CreateAsync(user, "Ja@12");
                            await userManager.AddToRoleAsync(user, UserRoles.Dealer.ToString());
                        }
                        else
                        {
                            user.EmailConfirmed = true;
                            await userManager.CreateAsync(user, "Ja@12");
                            await userManager.AddToRoleAsync(user, UserRoles.Customer.ToString());
                        }
                        count++;
                    }
                }
            }
            private static async Task SeedDealers(UserManager<User> userManager, AppDbContext dbContext)
            {
                if (!dbContext.Dealers.Any())
                {
                    var dealers = SeederHelper<Dealer>.GetData("Dealer.json");
                    await dbContext.Dealers.AddRangeAsync(dealers);
                    await dbContext.SaveChangesAsync();
                    foreach (var dealer in dealers)
                    {
                        var dealerExist = await userManager.FindByIdAsync(dealer.UserId.ToString());
                        await userManager.CreateAsync(dealerExist, "Ja@12");
                    }
                }
            }
        }
    }
}
