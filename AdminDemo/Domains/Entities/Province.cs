namespace AdminDemo.Domains.Entities
{
    public class Province
    {
        private string id;
        private string provinceName;
        private string provinceCode;
        private string countryId;

        public Province()
        {
        }

        public Province(string id, string provinceName, string provinceCode, string countryId)
        {
            this.id = id;
            this.provinceName = provinceName;
            this.provinceCode = provinceCode;
            this.countryId = countryId;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string ProvinceName
        {
            get => provinceName;
            set => provinceName = value;
        }

        public string ProvinceCode
        {
            get => provinceCode;
            set => provinceCode = value;
        }

        public string CountryId
        {
            get => countryId;
            set => countryId = value;
        }
    }
}