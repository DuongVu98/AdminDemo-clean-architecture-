using System.Collections.Generic;
using System.Threading.Tasks;
using AdminDemo.Adapters.Models;
using AdminDemo.Adapters.ModelsBuilder;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Interactors;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;

namespace AdminDemo.Drivers.RestControllers
{
    
    [Route("/api/admin")]
    [ApiController]
    public class AdminController
    {
        private AdminUseCases _adminUseCases;
        
        private TransactionBuilder _transactionBuilder;
        private UserBuilder _userBuilder;
        private ProvinceBuilder _provinceBuilder;

        public AdminController(AdminUseCases adminUseCases, TransactionBuilder transactionBuilder, UserBuilder userBuilder, ProvinceBuilder provinceBuilder)
        {
            _adminUseCases = adminUseCases;
            _transactionBuilder = transactionBuilder;
            _userBuilder = userBuilder;
            _provinceBuilder = provinceBuilder;
        }

        [HttpGet("transactions/{limit}")]
        public async Task<ActionResult<TransactionWeb>> FindAllTransactionsWeb(int limit)
        {
            TransactionWeb transactionWeb = new TransactionWeb();
            transactionWeb.Transactions = _transactionBuilder.ListBuild(_adminUseCases.FindAllTransactions(limit));
            transactionWeb.Count = _adminUseCases.TransactionsCount();

            return transactionWeb;
        }
        
        [HttpGet("transactions/search/by-user/{username}/{limit}")]
        public async Task<ActionResult<TransactionWeb>> TransactionSearchByUsername(int limit, string username)
        {
            TransactionWeb transactionWeb = new TransactionWeb();
            transactionWeb.Transactions = _transactionBuilder.ListBuild(_adminUseCases.TransactionsSearchByUserName(username, limit));
            transactionWeb.Count = _adminUseCases.TransactionsSearchByUserNameCount(username);

            return transactionWeb;
        }

        
        
        
        [HttpGet("users/{limit}")]
        public async Task<ActionResult<UserWeb>> FindAllUsersWeb(int limit)
        {
            UserWeb userWeb = new UserWeb();
            userWeb.Users = _userBuilder.ListBuild(_adminUseCases.FindAllUsers(limit));
            foreach (var user in userWeb.Users)
            {
                user.Provinces = _provinceBuilder.Build(_adminUseCases.FindProvinceById(user.ProvincesId));
            }
            userWeb.Count = _adminUseCases.UsersCount();

            return userWeb;
        }

        [HttpGet("users/search/by-username/{username}/{limit}")]
        public async Task<ActionResult<UserWeb>> UserSearchByUserName(string username, int limit)
        {
            UserWeb userWeb = new UserWeb();
            userWeb.Users = _userBuilder.ListBuild(_adminUseCases.UserSearchByUserName(username, limit));
            foreach (var user in userWeb.Users)
            {
                user.Provinces = _provinceBuilder.Build(_adminUseCases.FindProvinceById(user.ProvincesId));
            }
            userWeb.Count = _adminUseCases.UserSearchByUserNameCount(username);

            return userWeb;
        }
    }
}