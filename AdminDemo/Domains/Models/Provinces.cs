using System;
using System.Collections.Generic;

namespace AdminDemo.Models
{
    public partial class Provinces
    {
        public Provinces()
        {
            Users = new HashSet<Users>();
        }

        public string Id { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public string CountriesId { get; set; }

        public virtual Countries Countries { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
