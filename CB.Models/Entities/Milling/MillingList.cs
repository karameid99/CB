using System.ComponentModel.DataAnnotations;

namespace CB.Models.Entities.Mailing
{
   public class MillingList : BaseEntity
    {
        [Key]
        public string Email { get; set; }
    }
}
