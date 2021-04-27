using CB.Models.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CB.Data.Data
{
    public class CBDbContext : IdentityDbContext<CBUser>
    {
        public CBDbContext(DbContextOptions<CBDbContext> options)
            : base(options)
        {
        }
    }
}
