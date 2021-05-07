using CB.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime? LastLogin { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public UserType UserType { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public CB.Models.Entities.Client.Client Client { get; set; }
        public int? RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        public CBUser()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
