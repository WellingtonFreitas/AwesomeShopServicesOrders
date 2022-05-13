using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Bases
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Data = new List<object>();
            Messages = new List<string>(); ;
        }

        public ICollection<object> Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ICollection<string> Messages { get; set; }

    }
}

