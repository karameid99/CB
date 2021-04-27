using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Models
{
    public class APIResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public class APIResponseError : APIResponse
    {
        public object Error { get; set; }
    }
}
