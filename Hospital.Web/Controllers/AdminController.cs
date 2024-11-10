using Hospital.Data.Entities.Identity;
using Hospital.Service.UserService.DTOs;
using Hospital.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Store.Web.Controllers
{
    //[Authorize(Roles = "Administrator")]
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
                id = r.Id,
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
        [HttpPost]
        public async Task<ActionResult<string>> AddToRole(string UserId, string RoleName)
        {
            var user = await userManager.FindByIdAsync(UserId);
            var role = await roleManager.FindByNameAsync(RoleName);
            if (user is null)
            {
                throw new Exception($"no user found with Id:{UserId} ");
                return BadRequest();
            }
            if (role is null)
            {
                throw new Exception($" the role named {RoleName} dose not exist");
                return BadRequest();
            }
            var InRole = await userManager.IsInRoleAsync(user, RoleName);
            if (InRole)
                throw new Exception("this user Already in role");

            await userManager.AddToRoleAsync(user, RoleName);
            return Ok("User Added To Role successfully");
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
                throw new Exception($"user with id {userId} not found");

            await userManager.DeleteAsync(user);
            return Ok(true);
        }


    }
}
