using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.ViewModels.Client
{
    public class ClientProfileVm : ClientVm
    {
        public string Bio { get; set; }
        public float TotalPurchased { get; set; }
        public float TotalSold { get; set; }
        public float TotalAuctions { get; set; }
        public float TotalBids { get; set; }
        public float TotalComments { get; set; }
        public float TotalLikes { get; set; }
    }
}
