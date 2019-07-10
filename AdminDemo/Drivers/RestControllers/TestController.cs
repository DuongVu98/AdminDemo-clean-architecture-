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
    
    [Route("/api/test")]
    [ApiController]
    public class TestController
    {
        private AdminUseCases _adminUseCases;
        
        private TransactionBuilder _transactionBuilder;
        private UserBuilder _userBuilder;

        public TestController(AdminUseCases adminUseCases, TransactionBuilder transactionBuilder, UserBuilder userBuilder)
        {
            _adminUseCases = adminUseCases;
            _transactionBuilder = transactionBuilder;
            _userBuilder = userBuilder;
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
            transactionWeb.Count = _adminUseCases.transactionsSearchByUserNameCount(username);

            return transactionWeb;
        }

        
        
        
        [HttpGet("users/{limit}")]
        public async Task<ActionResult<UserWeb>> FindAllUsersWeb(int limit)
        {
            UserWeb userWeb = new UserWeb();
            userWeb.Users = _userBuilder.ListBuild(_adminUseCases.FindAllUsers(limit));
            userWeb.Count = _adminUseCases.UsersCount();

            return userWeb;
        }
    }
}