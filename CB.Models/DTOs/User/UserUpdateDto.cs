using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.DTOs.User
{
    public class UserUpdateDto : UserCreateDto
    {
        public string Id { get; set; }
    }
}
