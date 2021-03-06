using CB.Models.Entities.Client;
using CB.Models.Entities.Country;
using CB.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CB.Models.Entities.Car
{
    public class Auction : BaseEntity
    {
        public AuctionStatus Status { get; set; }
        public SellerType SellerType { get; set; }
        public string DealershipName { get; set; }
        public string DealershipWebsite { get; set; }
        public string SellerName { get; set; }
        public string SellerPhone { get; set; }
        public string NoteWorthy { get; set; }
        public bool SaleElsewhere { get; set; }
        public string ExistingList { get; set; }
        public string Year { get; set; }
        public string Model { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public bool IsModified { get; set; }
        public string ModifiedVehicle { get; set; }
        public string VehicleOwner { get; set; }
        public string Referral { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public float? ReservePrice { get; set; }
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
        public DateTime? EndingAt { get; set; }
        public int MakeId { get; set; }
        [ForeignKey(nameof(MakeId))]
        public BrandCar Make { get; set; }
        public int CarCityId { get; set; }
        [ForeignKey(nameof(CarCityId))]
        public City CarCity { get; set; }
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
        public int SellerId { get; set; }
        [ForeignKey(nameof(SellerId))]
        public CB.Models.Entities.Client.Client Seller { get; set; }
        public int? BayerId { get; set; }
        [ForeignKey(nameof(BayerId))]
        public CB.Models.Entities.Client.Client Bayer { get; set; }
        public List<Comment> Comment { get; set; }
        public List<Bid> Bids { get; set; }
        public List<AuctionLink> AuctionLinks { get; set; }
        public List<AuctionWatch> AuctionWatchs { get; set; }

    }
}
