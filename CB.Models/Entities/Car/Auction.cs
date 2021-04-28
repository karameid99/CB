using CB.Models.Entities.Country;
using CB.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CB.Models.Entities.Car
{
    public class Auction : BaseEntity
    {
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
        public int MakeId { get; set; }
        [ForeignKey(nameof(MakeId))]
        public BrandCar Make { get; set; }
        public int CarCityId { get; set; }
        [ForeignKey(nameof(CarCityId))]
        public City CarCity { get; set; }
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
    }
}
