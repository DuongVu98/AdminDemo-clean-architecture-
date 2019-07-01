using System.Collections.Generic;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.Repositories;

namespace AdminDemo.Usecases.Interactors
{
    public class UseCases
    {
        private IRepository<User> userRepository;
        private IRepository<Transaction> transactionRepository;
        private IRepository<Country> countryRepository;
        private IRepository<Province> provinceRepository;

        public UseCases(IRepository<User> userRepository, IRepository<Transaction> transactionRepository, IRepository<Country> countryRepository, IRepository<Province> provinceRepository)
        {
            this.userRepository = userRepository;
            this.transactionRepository = transactionRepository;
            this.countryRepository = countryRepository;
            this.provinceRepository = provinceRepository;
        }

        public List<User> FindAllUsers()
        {
            return userRepository.FindAll();
        }

        public User FindUserById(string id)
        {
            return userRepository.FindById(id);
        }

        public List<Transaction> FindAllTransactions()
        {
            return transactionRepository.FindAll();
        }
        
        public List<Transaction> FindAllTransactionsWithLimit(int limit)
        {
            return transactionRepository.FindOnePart(limit);
        }

        public Transaction findTransaction(Transaction transaction)
        {
            return transactionRepository.FindById(transaction.Id);
        }

        public int TransactionCounting()
        {
            return transactionRepository.Count();
        }
        

        public Country FindCountryById(string id)
        {
            return countryRepository.FindById(id);
        }
        
        public Province FindProviceById(string id)
        {
            return provinceRepository.FindById(id);
        }
    }
}