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
        private ICountryRepository _countryRepository;
        private IProvinceRepository _provinceRepository;

        public AdminUseCases(ITransactionRepository transactionRepository, IUserRepository userRepository, ICountryRepository countryRepository, IProvinceRepository provinceRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
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

        public int UsersCount()
        {
            return _userRepository.Count();
        }

        public Users FindUserById(string id)
        {
            return _userRepository.FindById(id);
        }


        // Countries Business Logic

        public List<Countries> FindAllCountries(int limit)
        {
            return _countryRepository.FindAll(limit);
        }

        public int CountryCount()
        {
            return _countryRepository.Count();
        }

        public Countries FindCountryById(string id)
        {
            return _countryRepository.FindById(id);
        }
        
        
        // Province Business Logic
        public List<Provinces> FindAllProvincesByCountryId(string id, int limit)
        {
            return _provinceRepository.FindByCountryId(id, limit);
        }

        public int ProvinceByCountryIdCount(string id)
        {
            return _provinceRepository.CountFindByCountryId(id);
        }

        public Provinces FindProvinceById(string id)
        {
            return _provinceRepository.FindById(id);
        }

    }
}