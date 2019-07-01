using System.Collections.Generic;
using AdminDemo.Domains.Entities;

namespace AdminDemo.Usecases.Repositories
{
    public interface ICountryRepository
    {
        List<Country> findAll();
        Country findById(string id);
        void Create(Country country);
        void Update(Country country);
        void Delete(Country country);
    }
}