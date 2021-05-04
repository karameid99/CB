using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.ViewModels.Supervisor
{
   public class SupervisorVm
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedAt { get; set; }
        public string LastLogin { get; set; }
        public bool IsActive { get; set; }
    }
}
