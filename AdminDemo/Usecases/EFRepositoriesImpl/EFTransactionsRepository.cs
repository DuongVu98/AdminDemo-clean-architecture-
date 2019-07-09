using System.Collections.Generic;
using System.Linq;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdminDemo.Usecases.EFRepositoriesImpl
{

    
    
    public class EFTransactionsRepository : IRepository<Transactions>, ICountingService<Transactions>, ISearchingService<Transactions>
    {
        private mydbContext context =new mydbContext();
        public List<Transactions> FindAll()
        {
            List<Transactions> transactionsList = context.Transactions
                .Include(t => t.Countries)
                .Include(t => t.Users)
                .ToList();
            return transactionsList;
        }

        public List<Transactions> FindOnePart(int limit, int amount)
        {
            throw new System.NotImplementedException();
        }

        public Transactions FindById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Transactions t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Transactions t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Transactions t)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public List<string> SearchString(string str)
        {
            throw new System.NotImplementedException();
        }
    }
}