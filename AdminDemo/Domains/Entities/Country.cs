namespace AdminDemo.Domains.Entities
{
    public class Country
    {
        private string id;
        private string countryName;
        private string countryCode;

        public Country()
        {
        }

        public Country(string id ,string countryName, string countryCode)
        {
            this.id = id;
            this.countryName = countryName;
            this.countryCode = countryCode;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string CountryName
        {
            get => countryName;
            set => countryName = value;
        }

        public string CountryCode
        {
            get => countryCode;
            set => countryCode = value;
        }
    }
}