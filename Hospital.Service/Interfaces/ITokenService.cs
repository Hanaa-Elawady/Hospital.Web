using Hospital.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user, string roleName = "User");
    }
}
