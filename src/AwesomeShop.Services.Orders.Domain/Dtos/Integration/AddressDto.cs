﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Domain.Dtos.Integration
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}