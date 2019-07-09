using System.Collections.Generic;
using System.Linq;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdminDemo.Usecases.EFRepositoriesImpl
{
    public class EFProvinceRepositoy : IProvinceRepository
    {
        private mydbContext context = new mydbContext();
        private int amount = 5;
        
        public List<Provinces> FindAll()
        {
            return context.Provinces.ToList();
        }

        public List<Provinces> FindAll(int limit)
        {
            return context.Provinces.Skip(limit).Take(amount).ToList();
        }

        public int Count()
        {
            return context.Provinces.Count();
        }

        public Provinces FindById(string id)
        {
            return context.Provinces.Single(p => p.Id == id);
        }

        public List<Provinces> FindByCountryId(string id)
        {
            return context.Provinces.Where(p => p.CountriesId == id).ToList();
        }

        public List<Provinces> FindByCountryId(string id, int limit)
        {
            return context.Provinces.Where(p => p.CountriesId == id).Skip(limit).Take(amount).ToList();
        }

        public int CountFindByCountryId(string id)
        {
            return context.Provinces.Where(p => p.CountriesId == id).Count();
        }

        public List<Provinces> SearchByProvinceName(string provinceName)
        {
            return context.Provinces.Where(p => EF.Functions.Like(p.ProvinceName, "%" + provinceName + "%")).ToList();
        }

        public List<Provinces> SearchByProvinceName(string provinceName, int limit)
        {
            return context.Provinces.Where(p => EF.Functions.Like(p.ProvinceName, "%" + provinceName + "%")).Skip(limit).Take(amount).ToList();
        }

        public int CountSearchByProvinceName(string provinceName)
        {
            return context.Provinces.Where(p => EF.Functions.Like(p.ProvinceName, "%" + provinceName + "%")).Count();
        }
    }
}