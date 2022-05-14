using AwesomeShop.Services.Orders.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Commands.Orders.Add
{
    public class AddOrderRequestResponse : ResponseBase
    {
        public Guid Id { get; set; }
    }
}
