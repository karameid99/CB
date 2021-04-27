using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Exceptions
{
   public class CBErrorException : Exception
    {
        public CBErrorException() { }
        public CBErrorException(string message) : base(message) { }
    }
}
