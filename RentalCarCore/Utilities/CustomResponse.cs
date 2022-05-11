using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarCore.Utilities
{
    public class CustomResponse<T>
    {

        public bool Success { get; set; }
        public string Message { get; set; }
        public string Errors { get; set; }
    }
}
