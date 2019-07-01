using System.Collections.Generic;
using AdminDemo.Domains.Entities;

namespace AdminDemo.Usecases.Repositories
{
    public interface ITransactionRepository
    {
        List<Transaction> findAll();

        List<Transaction> FindOnePart(int limit);
        Transaction findById(string id);
        void Create(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(Transaction transaction);
    }
}