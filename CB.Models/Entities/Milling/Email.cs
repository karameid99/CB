using CB.Models.Entities;
using CB.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Mailing.Entities
{
   public class Email : BaseEntity
    {
        public string Destination { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime? SendAt { get; set; }
        public DateTime? ScheduleAt { get; set; }
        public MillingStatus Status  { get; set; }
    }
}
