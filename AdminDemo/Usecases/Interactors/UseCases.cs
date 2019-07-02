using System;
using System.Collections.Generic;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.Repositories;

namespace AdminDemo.Usecases.Interactors
{
    public class UseCases
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        
        private IRepository<User> userRepository;
        private IRepository<Transaction> transactionRepository;
        private IRepository<Country> countryRepository;
        private IRepository<Province> provinceRepository;
        private TransactionsQuery query;

        public UseCases(IRepository<User> userRepository, IRepository<Transaction> transactionRepository, IRepository<Country> countryRepository, IRepository<Province> provinceRepository, TransactionsQuery query)
        {
            this.userRepository = userRepository;
            this.transactionRepository = transactionRepository;
            this.countryRepository = countryRepository;
            this.provinceRepository = provinceRepository;
            // Configuration of  TransactionsQuery
            this.query = new TransactionsQuery(4,0);
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
            return transactionRepository.FindOnePart(limit, query.TransactionsPerQuery);
        }

        public Transaction findTransaction(Transaction transaction)
        {
            return transactionRepository.FindById(transaction.Id);
        }

        public TransactionsQuery TransactionCounting()
        {
            query.NumberOfAllTransactions = transactionRepository.Count();
            Logger.Info("Transparent per query ----> {}", query.TransactionsPerQuery);
//            query.TransactionsPerQuery = 2;
//            return transactionRepository.Count();
            return query;
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