using System;
using System.Collections.Generic;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.Repositories;

namespace AdminDemo.Usecases.Interactors
{
    public class UseCases
    {
//        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        
        private IRepository<User> userRepository;
        private IRepository<Transaction> transactionRepository;
        private IRepository<Country> countryRepository;
        private IRepository<Province> provinceRepository;
        private TransactionsQuery query;

        public ISearchingRepository<Transaction> transactionsSearch;

        public UseCases(IRepository<User> userRepository, IRepository<Transaction> transactionRepository, IRepository<Country> countryRepository, IRepository<Province> provinceRepository, TransactionsQuery query, ISearchingRepository<Transaction> transactionsSearch)
        {
            this.userRepository = userRepository;
            this.transactionRepository = transactionRepository;
            this.countryRepository = countryRepository;
            this.provinceRepository = provinceRepository;
            this.query = new TransactionsQuery(5,0);
            this.transactionsSearch = transactionsSearch;
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

        public Transaction findTransactionById(string id)
        {
            return transactionRepository.FindById(id);
        }

        public TransactionsQuery TransactionCounting()
        {
            query.NumberOfAllTransactions = transactionRepository.Count();
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

        public List<Transaction> TransactionsSearching(string str)
        {
            return transactionsSearch.SearchString(str);
        }
    }
}