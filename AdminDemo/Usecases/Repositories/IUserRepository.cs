using System.Collections.Generic;
using AdminDemo.Domains.Entities;
using AdminDemo.Domains.Models;

namespace AdminDemo.Usecases.Repositories
{
    public interface IUserRepository
    {
        List<Users> FindAll();
        List<Users> FindAll(int limit);
        int Count();

        Users FindById(string id);

        List<Users> FindByProvinceId(string id);
        List<Users> FindByProvinceId(string id, int limit);
        int CountFindByProvinceId(string id);
        
        List<Users> FindByCountryId(string id);
        List<Users> FindByCountryId(string id, int limit);
        int CountFindByCountryId(string id);

        List<Users> SearchByUserName(string userName);
        List<Users> SearchByUserName(string userName, int limit);
        int CountSearchByUserName(string userName);
        
        List<Users> SearchByProvinceName(string userName);
        List<Users> SearchByProvinceName(string userName, int limit);
        int CountSearchByProvinceName(string userName);
    }
}