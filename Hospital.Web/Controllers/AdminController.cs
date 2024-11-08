using Hospital.Data.Entities.Identity;
using Hospital.Service.UserService.DTOs;
using Hospital.Web.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Store.Web.Controllers
{

    public class AdminController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAllRoles()
        {
            var roles = await roleManager.Roles.ToListAsync();


            var rolesList = roles.Select(r => new RoleDTO
            {
                Name = r.Name
            }).ToList();

            return Ok(rolesList);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await userManager.Users.Select(u => new UserDTO
            {
                DisplayName = u.UserName,
                Email = u.Email,
                Id = Guid.Parse(u.Id),
                PhoneNumber = u.PhoneNumber,
                Roles = userManager.GetRolesAsync(u).Result

            }).ToListAsync();

            return Ok(users);
        }


    }
}
