using System.Collections.Generic;
using System.Linq;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdminDemo.Usecases.EFRepositoriesImpl
{
    public class EFCountryRepository : ICountryRepository
    {
        private mydbContext context = new mydbContext();
        private int amount = 10;
        
        public List<Countries> FindAll()
        {
            return context.Countries.ToList();
        }

        public List<Countries> FindAll(int limit)
        {
            return context.Countries.Skip(limit).Take(amount).ToList();
        }

        public int Count()
        {
            return context.Countries.Count();
        }

        public Countries FindById(string id)
        {
            return context.Countries.Single(c => c.Id == id);
        }

        public Countries FindByCountryCode(string code)
        {
            return context.Countries.Single(c => c.CountryCode == code);
        }

        public List<Countries> SearchByCountryName(string countryName)
        {
            return context.Countries.Where(c => EF.Functions.Like(c.CountryName, "%" + countryName + "%")).ToList();
        }

        public List<Countries> SearchByCountryName(string countryName, int limit)
        {
            return context.Countries.Where(c => EF.Functions.Like(c.CountryName, "%" + countryName + "%")).Skip(limit).Take(amount).ToList();
        }

        public int CountSearchByCountryName(string countryName)
        {
            return context.Countries.Where(c => EF.Functions.Like(c.CountryName, "%" + countryName + "%")).Count();
        }

        public List<Countries> SearchByCountryCode(string countryCode)
        {
            return context.Countries.Where(c => EF.Functions.Like(c.CountryCode, "%" + countryCode + "%")).ToList();
        }

        public List<Countries> SearchByCountryCode(string countryCode, int limit)
        {
            return context.Countries.Where(c => EF.Functions.Like(c.CountryCode, "%" + countryCode + "%")).Skip(limit).Take(amount).ToList();
        }

        public int CountSearchByCountryCode(string countryCode)
        {
            return context.Countries.Where(c => EF.Functions.Like(c.CountryCode, "%" + countryCode + "%")).Count();
        }
    }
}