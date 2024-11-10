using Hospital.Data.Entities.Identity;
using Hospital.Service.Interfaces;
using Hospital.Service.UserService.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.UserService
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }
        public async Task<AuthDTO> LogIn(LoginDTO input)
        {
            var user = await userManager.FindByEmailAsync(input.Email);
            if (user == null)
                throw new Exception("This email is not Found");


            var IsTrue = await signInManager.CheckPasswordSignInAsync(user, input.Password, false);
            var roles = await userManager.GetRolesAsync(user);
            var result = new AuthDTO
            {
                Id = Guid.Parse(user.Id),
                DisplayName = user.UserName,
                Email = user.Email,
                Token = tokenService.GenerateToken(user, string.Join(",", roles)),
            };
            return result;
        }

        public async Task<AuthDTO> Register(RegisterDTO input)
        {
            var userExist = await userManager.FindByEmailAsync(input.Email);

            if (userExist is not null)
                throw new Exception("This email Has An Account");

            var user = new AppUser
            {
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                UserName = input.Name
            };
            await userManager.CreateAsync(user, input.Password);

            var result = new AuthDTO
            {
                Id = Guid.Parse(user.Id),
                DisplayName = user.UserName,
                Email = user.Email,
                Token = tokenService.GenerateToken(user),
            };
            return result;
        }
    }
}
