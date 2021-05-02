using CB.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CB.Models.Entities.Car
{
   public class AuctionLink
    {
        public int Id { get; set; }
        public LinkType ImageType { get; set; }
        public string Image { get; set; }
        public int AuctionId { get; set; }
        [ForeignKey(nameof(AuctionId))]
        public Auction Auction { get; set; }
    }
}
