using System;
using System.Collections.Generic;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.Repositories;
using AdminDemo.Usecases.RepositoriesImpl;

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

        public ISearchingService<Transaction> transactionsSearch;
        public ICountingService<Transaction> transactionsCounting;

        public UseCases(IRepository<User> userRepository, IRepository<Transaction> transactionRepository, IRepository<Country> countryRepository, IRepository<Province> provinceRepository, TransactionsQuery query, ISearchingService<Transaction> transactionsSearch, ICountingService<Transaction> transactionsCounting)
        {
            this.userRepository = userRepository;
            this.transactionRepository = transactionRepository;
            this.countryRepository = countryRepository;
            this.provinceRepository = provinceRepository;
            this.query = new TransactionsQuery(5,0);
            this.transactionsSearch = transactionsSearch;
            this.transactionsCounting = transactionsCounting;
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
            query.NumberOfAllTransactions = transactionsCounting.Count();
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
//            MySqlTransactionRepository test = new MySqlTransactionRepository();
            List<Transaction> transactions = new List<Transaction>();
            Transaction khoa = findTransactionById("vp");
            List<string> ids = transactionsSearch.SearchString(str);
            
            foreach (var id in ids)
            {
                if (Equals(id, "no rows"))
                {
//                    transactions.Add(khoa);
                    return transactions;
                }
                else
                {
                    transactions.Add(findTransactionById(id));
                }
                
            }
            
            return transactions;
        }
    }
}