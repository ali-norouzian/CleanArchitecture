using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GeneralResponse
    {
        public GeneralResponse(string message = "عمیات با موفقیت انجام شد")
        {
            Message = message;
        }
        public string Message { get; set; }

    }
}
