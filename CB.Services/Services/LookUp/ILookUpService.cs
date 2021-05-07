using CB.Models.DTOs.LookUp;
using CB.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Infrastructure.Services.LookUp
{
    public interface ILookUpService
    {
        List<Permissions> GetPermission();
    }
}
