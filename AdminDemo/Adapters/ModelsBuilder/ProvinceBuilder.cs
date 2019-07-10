using System.Collections.Generic;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Interactors;

namespace AdminDemo.Adapters.ModelsBuilder
{
    public class ProvinceBuilder
    {
        private AdminUseCases _adminUseCases;

        public ProvinceBuilder(AdminUseCases adminUseCases)
        {
            _adminUseCases = adminUseCases;
        }

        public Provinces Build(Provinces province)
        {
            province.Countries = _adminUseCases.FindCountryById(province.CountriesId);

            return province;
        }

        public List<Provinces> ListBuild(List<Provinces> provinces)
        {
            foreach (var province in provinces)
            {
                province.Countries = _adminUseCases.FindCountryById(province.CountriesId);
            }

            return provinces;
        }
    }
}