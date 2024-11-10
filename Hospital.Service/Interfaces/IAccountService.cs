using Hospital.Service.UserService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<AuthDTO> LogIn(LoginDTO input);
        public Task<AuthDTO> Register(RegisterDTO input);
    }
}
