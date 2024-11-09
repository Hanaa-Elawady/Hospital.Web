using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.UserService.DTOs
{
    public class UserRoleDTo
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public ICollection<RoleMangeDTO> Role { get; set; }
    }
}
