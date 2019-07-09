using System.Collections.Generic;
using AdminDemo.Domains.Entities;
using AdminDemo.Domains.Models;

namespace AdminDemo.Usecases.Repositories
{
    public interface IProvinceRepository
    {
        List<Provinces> FindAll();
        List<Provinces> FindAll(int limit);
        int Count();

        Provinces FindById(string id);

        List<Provinces> FindByCountryId(string id);
        List<Provinces> FindByCountryId(string id, int limit);
        int CountFindByCountryId(string id);
        

        List<Provinces> SearchByProvinceName(string provinceName);
        List<Provinces> SearchByProvinceName(string provinceName, int limit);
        int CountSearchByProvinceName(string provinceName);
    }
}