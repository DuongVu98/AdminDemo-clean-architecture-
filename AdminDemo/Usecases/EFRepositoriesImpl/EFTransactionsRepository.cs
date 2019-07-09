using System.Collections.Generic;
using System.Linq;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdminDemo.Usecases.EFRepositoriesImpl
{
    public class EFTransactionsRepository : ITransactionRepository
    {
        private mydbContext context =new mydbContext();
        private int amount = 5;
        
        public List<Transactions> FindAll()
        {
            return context.Transactions.ToList();
        }

        public Transactions FindById(string id)
        {
            return context.Transactions.Single(t => t.Id == id);
        }

        public List<Transactions> FindByUserId(string id)
        {
            return context.Transactions.Where(t => t.UsersId == id).ToList();
        }

        public List<Transactions> FindByCountryId(string id)
        {
            return context.Transactions.Where(t => t.CountriesId == id).ToList();
        }

        public List<Transactions> SearchByUserName(string userName)
        {
            string str = "%" + userName + "%";
            List<Transactions> transactions = new List<Transactions>();
            var innerJoin = from t in context.Transactions
                join u in context.Users on t.UsersId equals u.Id
                where EF.Functions.Like(u.UserName, str)
                select new
                {
                    Id = t.Id
                };
            
            foreach (var transactionId in innerJoin)
            {
                transactions.Add(context.Transactions.Single(t => t.Id == transactionId.Id));
            }

            return transactions;
        }

        public List<Transactions> SearchByCountryName(string countryName)
        {
            throw new System.NotImplementedException();
        }

        public List<Transactions> FindAll(int limit)
        {
            return context.Transactions.Skip(limit).Take(amount).ToList();
        }

        public List<Transactions> FindByUserId(string id, int limit)
        {
            return context.Transactions.Where(t => t.UsersId == id).Skip(limit).Take(amount).ToList();
        }

        public List<Transactions> FindByCountryId(string id, int limit)
        {
            return context.Transactions.Where(t => t.CountriesId == id).Skip(limit).Take(amount).ToList();
        }
        
        public List<Transactions> SearchByUserName(string userName, int limit)
        {
            string str = "%" + userName + "%";
            List<Transactions> transactions = new List<Transactions>();
            var innerJoin = (from t in context.Transactions
                join u in context.Users on t.UsersId equals u.Id
                where EF.Functions.Like(u.UserName,  str) ||
                      EF.Functions.Like(u.FirstName, str) ||
                      EF.Functions.Like(u.LastName, str)
                select new
                {
                    Id = t.Id
                }).Skip(limit).Take(amount);
            
            foreach (var transactionId in innerJoin)
            {
                transactions.Add(context.Transactions.Single(t => t.Id == transactionId.Id));
            }

            return transactions;
        }

        public List<Transactions> SearchByCountryName(string provinceName, int limit)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Transactions transaction)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Transactions transaction)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Transactions transaction)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            return context.Transactions.Count();
        }

        public int CountFindByUserId(string id)
        {
            return context.Transactions.Where(t => t.UsersId == id).Count();
        }

        public int CountFindByCountryId(string id)
        {
            return context.Transactions.Where(t => t.CountriesId == id).Count();
        }

        public int CountSearchByUserName(string userName)
        {
            string str = "%" + userName + "%";
            return (from t in context.Transactions
                join u in context.Users on t.UsersId equals u.Id
                where EF.Functions.Like(u.UserName, str)
                select new
                {
                    Id = t.Id
                }).Count();
        }

        public int CountSearchByCountryName(string countryName)
        {
            throw new System.NotImplementedException();
        }
    }
}