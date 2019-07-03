using System.Collections.Generic;
using AdminDemo.Adapters.Models;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.Interactors;

namespace AdminDemo.Adapters.Presenters
{
    public class TransactionPresenter
    {
        private UseCases _usecases;

        public TransactionPresenter(UseCases usecases)
        {
            _usecases = usecases;
        }

        public List<PopulatedTransaction> FindAllPopulatedTransactions(List<Transaction> oldList)
        {
            List<PopulatedTransaction> populateTransactions = new List<PopulatedTransaction>();

//            List<Transaction> transactions = _usecases.FindAllTransactions();
            foreach (var transaction in oldList)
            {
                User user = _usecases.FindUserById(transaction.UserId);
                Country country = _usecases.FindCountryById(transaction.CountryId);
                Province province = _usecases.FindProviceById(user.ProvinceId);
                
                PopulatedUser populatedUser = new PopulatedUser(user.Id, user.Username, user.Password, user.FirstName, user.LastName, user.BirthDate, user.Address, province);
                populateTransactions.Add(new PopulatedTransaction(transaction.Id, populatedUser, transaction.Hash, transaction.Address, country));
            }

            return populateTransactions;
        }
        
        public List<PopulatedTransaction> FindAllPopulatedTransactionsWithLimit(int limit)
        {
            List<PopulatedTransaction> populateTransactions = new List<PopulatedTransaction>();

            List<Transaction> transactions = _usecases.FindAllTransactionsWithLimit(limit);
            
            foreach (var transaction in transactions)
            {
                User user = _usecases.FindUserById(transaction.UserId);
                Country country = _usecases.FindCountryById(transaction.CountryId);
                Province province = _usecases.FindProviceById(user.ProvinceId);
                
                PopulatedUser populatedUser = new PopulatedUser(user.Id, user.Username, user.Password, user.FirstName, user.LastName, user.BirthDate, user.Address, province);
                populateTransactions.Add(new PopulatedTransaction(transaction.Id, populatedUser, transaction.Hash, transaction.Address, country));
            }

            return populateTransactions;
        }
        
    }
}