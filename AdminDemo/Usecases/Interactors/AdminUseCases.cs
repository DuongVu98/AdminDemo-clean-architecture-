using System.Collections;
using System.Collections.Generic;
using AdminDemo.Domains.Entities;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Repositories;

namespace AdminDemo.Usecases.Interactors
{
    public class AdminUseCases
    {
        private ITransactionRepository _transactionRepository;
        private IUserRepository _userRepository;

        public AdminUseCases(ITransactionRepository transactionRepository, IUserRepository userRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
        }

        // Transactions Business Logics

        public List<Transactions> FindAllTransactions(int limit)
        {
            return _transactionRepository.FindAll(limit);
        }
        public int TransactionsCount()
        {
            return _transactionRepository.Count();
        }

        public Transactions FindTransactionById(string id)
        {
            return _transactionRepository.FindById(id);
        }

        public List<Transactions> transactionsSearchByUserName(string userName)
        {
            return _transactionRepository.SearchByUserName(userName);
        }

        public int transactionsSearchByUserNameCount(string userName)
        {
            return _transactionRepository.CountSearchByUserName(userName);
        }

        

        // Users Business Logic

        public List<Users> FindAllUsers(int limit)
        {
            return _userRepository.FindAll(limit);
        }

        public Users FindUserById(string id)
        {
            return _userRepository.FindById(id);
        }
    }
}