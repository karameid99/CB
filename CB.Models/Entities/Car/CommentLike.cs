using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Car
{
   public class CommentLike
    {
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public CB.Models.Entities.Client.Client Client { get; set; }
        [ForeignKey(nameof(CommentId))]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
