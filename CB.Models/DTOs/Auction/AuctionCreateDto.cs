using CB.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.DTOs.Auction
{
    public class AuctionCreateDto 
    {
        public SellerType SellerType { get; set; }
        [Required]
        public string DealershipName { get; set; }
        [Required]
        public string DealershipWebsite { get; set; }
        [Required]
        public string SellerName { get; set; }
        [Required]
        public string SellerPhone { get; set; }
        [Required]
        public string NoteWorthy { get; set; }
        [Required]
        public bool SaleElsewhere { get; set; }
        [Required]
        public string ExistingList { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Mileage { get; set; }
        [Required]
        public string VIN { get; set; }
        [Required]
        public bool IsModified { get; set; }
        [Required]
        public string ModifiedVehicle { get; set; }
        [Required]
        public string VehicleOwner { get; set; }
        [Required]
        public string Referral { get; set; }
        [Required]
        public VehicleStatus VehicleStatus { get; set; }
        public float? ReservePrice { get; set; }
        [Required]
        public string BodyStyle { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        public string Drivetrain { get; set; }
        [Required]
        public string Transmission { get; set; }
        [Required]
        public string ExteriorColor { get; set; }
        [Required]
        public string InteriorColor { get; set; }
        [Required]
        public string Highlights { get; set; }
        [Required]
        public string Equipment { get; set; }
        [Required]
        public string KnownFlaws { get; set; }
        [Required]
        public string RecentServiceHistory { get; set; }
        [Required]
        public string ItemsIncluded { get; set; }
        [Required]
        public string OwnershipHistory { get; set; }
        public DateTime? EndingAt { get; set; }
        [Required]
        public int? MakeId { get; set; }
        [Required]
        public int? CarCityId { get; set; }
        [Required]
        public int? CityId { get; set; }
        [Required]
        public int? SellerId { get; set; }
    }
}
