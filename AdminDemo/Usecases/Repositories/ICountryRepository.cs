using System.Collections.Generic;
using AdminDemo.Domains.Models;

namespace AdminDemo.Usecases.Repositories
{
    public interface ICountryRepository
    {
        List<Countries> FindAll();
        List<Countries> FindAll(int limit);
        int Count();

        Countries FindById(string id);
        Countries FindByCountryCode(string code);

        List<Countries> SearchByCountryName(string countryName);
        List<Countries> SearchByCountryName(string countryName, int limit);
        int CountSearchByCountryName(string countryName);
        
        List<Countries> SearchByCountryCode(string countryCode);
        List<Countries> SearchByCountryCode(string countryCode, int limit);
        int CountSearchByCountryCode(string countryCode);
        
    }
}