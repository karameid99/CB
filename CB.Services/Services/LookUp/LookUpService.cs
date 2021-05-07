using CB.Data.Data;
using CB.Models.DTOs.LookUp;
using CB.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.LookUp
{
    public class LookUpService : ILookUpService
    {
        private readonly CBDbContext _context;

        public LookUpService(CBDbContext context)
        {
            _context = context;
        }

        public List<Permissions> GetPermission()
        {
            return Enum.GetValues(typeof(Permissions)).Cast<Permissions>().ToList();
        }
    }
}
