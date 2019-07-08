using System;
using System.Collections.Generic;

namespace AdminDemo.Models
{
    public partial class Users
    {
        public Users()
        {
            Transactions = new HashSet<Transactions>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string ProvincesId { get; set; }

        public virtual Provinces Provinces { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
