using CB.Models.Entities.Car;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CB.Models.Entities.Client
{
    public class Bid : BaseEntity
    {
        public string BidText { get; set; }
        public float Price { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        public int AuctionId { get; set; }
        [ForeignKey(nameof(AuctionId))]
        public Auction Auction { get; set; }
        public List<BidLike> BidLikes { get; set; }
    }
}
