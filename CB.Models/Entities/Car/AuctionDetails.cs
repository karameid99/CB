using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Car
{
    public class AuctionDetails : BaseEntity
    {
        public string BodyStyle { get; set; }
        public string Engine { get; set; }
        public string Drivetrain { get; set; }
        public string Transmission { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }

        // More Details
        public string Highlights { get; set; }
        public string Equipment { get; set; }
        public string KnownFlaws { get; set; }
        public string RecentServiceHistory { get; set; }
        public string ItemsIncluded { get; set; }
        public string OwnershipHistory { get; set; }

    }
}
