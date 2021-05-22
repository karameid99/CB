using CB.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.ViewModels.Auction
{
    public class AuctionProfileVm :BaseVm
    {
        public AuctionStatus Status { get; set; }
        public string SellerName { get; set; }
        public string SellerPhone { get; set; }
        public string EndingAt { get; set; }
        public int Bids { get; set; }
        public int  Comments { get; set; }
    }
}
