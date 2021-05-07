using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Auth
{
    public class Role : BaseEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Permission { get; set; }
        public List<CBUser> Users { get; set; }
    }
}
