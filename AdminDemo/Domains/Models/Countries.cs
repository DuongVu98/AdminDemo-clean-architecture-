using System;
using System.Collections.Generic;

namespace AdminDemo.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Provinces = new HashSet<Provinces>();
            Transactions = new HashSet<Transactions>();
        }

        public string Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Provinces> Provinces { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
