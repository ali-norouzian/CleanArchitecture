using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string message = "عملیات با خطا مواجه شد") : base(message) { }

    }
}
