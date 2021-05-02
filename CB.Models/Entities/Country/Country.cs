using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.Country
{
    public class Country : BaseEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public List<City> Cities { get; set; }
    }
}
