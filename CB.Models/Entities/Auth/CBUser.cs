using CB.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Auth
{
    public class CBUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string FCMToken { get; set; }
        public string AccessToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public UserType UserType { get; set; }
    }
}
