using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.DTOs.Role
{
    public class RoleCreateDto
    {
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string Permission { get; set; }
    }
}
