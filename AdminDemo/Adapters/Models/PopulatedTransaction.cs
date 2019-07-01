using AdminDemo.Domains.Entities;

namespace AdminDemo.Adapters.Models
{
    public class PopulatedTransaction
    {
        private string id;
        private PopulatedUser user;
        private string hash;
        private string address;
        private Country country;

        public PopulatedTransaction()
        {
        }

        public PopulatedTransaction(string id, PopulatedUser user, string hash, string address, Country country)
        {
            this.id = id;
            this.user = user;
            this.hash = hash;
            this.address = address;
            this.country = country;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public PopulatedUser User
        {
            get => user;
            set => user = value;
        }

        public string Hash
        {
            get => hash;
            set => hash = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public Country Country
        {
            get => country;
            set => country = value;
        }
    }
}