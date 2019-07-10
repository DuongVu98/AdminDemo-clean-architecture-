using System.Collections.Generic;
using AdminDemo.Domains.Entities;
using AdminDemo.Domains.Models;

namespace AdminDemo.Usecases.Repositories
{
    public interface ITransactionRepository
    {
        List<Transactions> FindAll();
        Transactions FindById(string id);
        List<Transactions> FindByUserId(string id);
        List<Transactions> FindByCountryId(string id);
        List<Transactions> SearchByUserName(string userName);
        List<Transactions> SearchByCountryName(string countryName);
        
        List<Transactions> FindAll(int limit);
        List<Transactions> FindByUserId(string id, int limit);
        List<Transactions> FindByCountryId(string id, int limit);
        List<Transactions> SearchByUserName(string userName, int limit);
        List<Transactions> SearchByCountryName(string provinceName, int limit);
        
        void Create(Transactions transaction);
        void Update(Transactions transaction);
        void Delete(Transactions transaction);

        int Count();
        int CountFindByUserId(string id);
        int CountFindByCountryId(string id);
        int CountSearchByUserName(string userName);
        int CountSearchByCountryName(string countryName);
    }
}