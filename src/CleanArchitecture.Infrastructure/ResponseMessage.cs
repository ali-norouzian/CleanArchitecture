using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ResponseMessage
    {
        public string errorMessage { get; set; }
        public ResponseStatus status { get; set; }
        public object result { get; set; } = new object();

        private ResponseMessage(string err)
        {
            errorMessage = err;
        }

        public static ResponseMessage Success<T>(T data)
        {
            return new ResponseMessage(null)
            {
                status = ResponseStatus.OK,
                result = data
            };
        }

        public static ResponseMessage Error(string errorMessage)
        {
            return new ResponseMessage(errorMessage)
            {
                status = ResponseStatus.NOK
            };
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public enum ResponseStatus
    {
        OK,
        NOK
    }

}
