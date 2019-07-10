using System.Collections.Generic;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Interactors;

namespace AdminDemo.Adapters.ModelsBuilder
{
    public class TransactionBuilder
    {
        private AdminUseCases _adminUseCases;

        public TransactionBuilder(AdminUseCases adminUseCases)
        {
            _adminUseCases = adminUseCases;
        }

        public Transactions Build(Transactions transaction)
        {
            transaction.Users = _adminUseCases.FindUserById(transaction.UsersId);
            transaction.Countries = _adminUseCases.FindCountryById(transaction.CountriesId);

            return transaction;
        }

        public List<Transactions> ListBuild(List<Transactions> transactions)
        {
            foreach (var transaction in transactions)
            {
                transaction.Users = _adminUseCases.FindUserById(transaction.UsersId);
                transaction.Countries = _adminUseCases.FindCountryById(transaction.CountriesId);
            }

            return transactions;
        }
    }
}