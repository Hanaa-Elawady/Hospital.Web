using Hospital.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Contexts
{
    public class HospitalIdentityDbContext : IdentityDbContext<AppUser>
    {
        public HospitalIdentityDbContext(DbContextOptions<HospitalIdentityDbContext> options) : base(options)
        {
        }
    }
}
