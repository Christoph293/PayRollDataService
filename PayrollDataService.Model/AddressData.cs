﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollDataService.Model
{
    public class AddressData
    {
        public int ID { get; set; }

        public string? Street { get; set; }

        public string? StreetNo { get; set; }

        public string? PostalCode { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }
    }
}
