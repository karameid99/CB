using System.ComponentModel.DataAnnotations.Schema;

namespace CB.Models.Entities.Car
{
   public class BrandCar : BaseEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public BrandCar ParentBrand { get; set; }
    }
}
