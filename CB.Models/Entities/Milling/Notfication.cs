using CB.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Mailing
{
    public class Notfication : BaseEntity
    {
        public string Destination { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? SendAt { get; set; }
        public DateTime? ScheduleAt { get; set; }
        public NotficationType Type { get; set; }
        public MillingStatus Status { get; set; }
    }
}
