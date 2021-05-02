using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Client
{
   public class BidLike
    {
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        [ForeignKey(nameof(BidId))]
        public int BidId { get; set; }
        public Bid Bid { get; set; }
    }
}
