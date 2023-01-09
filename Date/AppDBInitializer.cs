using DemoStore.Date.Static;
using DemoStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace DemoStore.Date
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Product - 1",
                            Price = 10000,
                            ImageURL = "https://bryanesvr.github.io/eCommerce-aspnet-mvc-application/Image-1.jfif",
                        }
                    });

                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));


                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string adminEmailId = "demostoreadmin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminEmailId);
                if (adminUser == null)
                {
                    var newAdminUser = new IdentityUser()
                    {
                        UserName = "admin",
                        Email = adminEmailId,
                        EmailConfirmed = true,
                    };

                    await userManager.CreateAsync(newAdminUser, "Demostore@1");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string userEmailId = "demostoreuser@gmail.com";

                var appUser = await userManager.FindByEmailAsync(userEmailId);
                if (appUser == null)
                {
                    var newAppUser = new IdentityUser()
                    {
                        UserName = "user",
                        Email = userEmailId,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAppUser, "Demostore@1");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }

    }
}
