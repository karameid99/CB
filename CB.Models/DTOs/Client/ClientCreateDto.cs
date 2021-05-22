using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.DTOs.Client
{
   public class ClientCreateDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
    }
}
