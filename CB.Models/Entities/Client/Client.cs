using CB.Models.Entities.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Client
{
    public class Client : BaseEntity
    {
        [Required]
        public string OwnerId { get; set; }
        [Key]
        public string UserName { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public CBUser Owner { get; set; }

        #region Notfications
        public bool DailyEmail { get; set; }
        public bool WeeklyEmail { get; set; }
        public bool MentionedInComments { get; set; }
        public bool Replies { get; set; }
        public bool PlaySound { get; set; }
        // WatchList Notfication
        public bool WatchBeforeEnd { get; set; }
        public bool WatchNewBid { get; set; }
        public bool WatchNewComments { get; set; }
        public bool WatchAuctionsResults { get; set; }
        //Seller Notifications
        public bool SellerNewCommentsOnEmail { get; set; }
        public bool SellerNewBidsOnEmail { get; set; }
        #endregion


    }
}
