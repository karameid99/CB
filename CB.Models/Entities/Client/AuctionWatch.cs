using CB.Models.Entities.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Client
{
    public class AuctionWatch
    {
        public int ClientId { get; set; }
        public CB.Models.Entities.Client.Client Client { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        public DateTime CreatedAt { get; set; }
        public AuctionWatch()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
