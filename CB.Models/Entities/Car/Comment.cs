using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Car
{
   public class Comment : BaseEntity
    {
        public string CommentText { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public CB.Models.Entities.Client.Client Client { get; set; }
        public int AuctionId { get; set; }
        [ForeignKey(nameof(AuctionId))]
        public Auction Auction { get; set; }
        public List<CommentLike> CommentLikes { get; set; }
    }
}
