using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Constants
{
   public static class Results
    {
        public static object AddSuccessResult()
        {
            return new { status = 1, msg = "s: Item successfully added", close = 1 };
        }
        public static object AddFuilerResult()
        {
            return new { status = 1, msg = "s: Item Not added", close = 1 };
        }
        public static object EditSuccessResult()
        {
            return new { status = 1, msg = "s: Item has been updated successfully ", close = 1 };
        }
        public static object DeleteSuccessResult()
        {
            return new { status = 1, msg = "s: Item has been deleted successfully", close = 1 };
        }
        public static object DeleteFailedResult()
        {
            return new { status = 1, msg = "s: Item has been Failed deleted", close = 1 };
        }
    }
}
