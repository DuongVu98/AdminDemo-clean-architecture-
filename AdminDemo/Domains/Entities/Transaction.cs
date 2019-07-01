namespace AdminDemo.Domains.Entities
{
    public class Transaction
    {
        private string id;
        private string userId;
        private string hash;
        private string address;
        private string countryId;

        public Transaction()
        {
        }

        public Transaction(string id, string userId, string hash, string address, string countryId)
        {
            this.id = id;
            this.userId = userId;
            this.hash = hash;
            this.address = address;
            this.countryId = countryId;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string UserId
        {
            get => userId;
            set => userId = value;
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

        public string CountryId
        {
            get => countryId;
            set => countryId = value;
        }
    }
}