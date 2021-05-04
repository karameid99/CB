using CB.Models.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.DTOs.Supervisor
{
    public class SupervisorCreateDto
    {
        [Required]
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

    }
}
