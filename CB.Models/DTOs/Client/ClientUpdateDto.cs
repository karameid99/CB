using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.DTOs.Client
{
    public class ClientUpdateDto : ClientCreateDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
    }
}
