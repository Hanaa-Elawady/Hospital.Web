using Hospital.Service.Interfaces;
using Hospital.Service.UserService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{

    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpPost]
        public async Task<ActionResult<AuthDTO>> LogIn(LoginDTO Input)
        => Ok(await accountService.LogIn(Input));

        [HttpPost]
        public async Task<ActionResult<AuthDTO>> Register(RegisterDTO Input)
        => Ok(await accountService.Register(Input));
    }
}
