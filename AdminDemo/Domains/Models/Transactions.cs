using System;
using System.Collections.Generic;

namespace AdminDemo.Models
{
    public partial class Transactions
    {
        public string Id { get; set; }
        public string Hash { get; set; }
        public string Address { get; set; }
        public string UsersId { get; set; }
        public string CountriesId { get; set; }

        public virtual Countries Countries { get; set; }
        public virtual Users Users { get; set; }
    }
}
