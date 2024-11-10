using Hospital.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Seeding
{
    public class AppUserSeeding
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    Email = "Youssef@gmail.com",
                    UserName = "YoussefAbdullah",
                    PhoneNumber = "1234567890",

                };


                await userManager.CreateAsync(user, "PA$$W0rd");

            }
        }

        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Define roles for the hospital system
            string[] roleNames = { "Doctor", "Nurse", "Receptionist", "Pharmacist", "Lab Technician", "Administrator", "User" };

            foreach (var roleName in roleNames)
            {
                // Check if the role already exists
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    // Create the role if it doesn't exist
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
