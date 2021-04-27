using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Models
{
    public class PagingVm
    {
        [Required]
        public int Total { get; set; }
        [Required]
        public string Data { get; set; }
    }
}
