using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AdminDemo.Adapters.Models;
using AdminDemo.Adapters.Presenters;
using AdminDemo.Domains.Entities;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Interactors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AdminDemo.Drivers.RestControllers
{
    [Route("/api/admin")]
    [ApiController]
    public class AdminController
    {
        private UseCases _usecases;
        private TransactionPresenter _transactionPresenter;
        private UserPresenter _userPresenter;

        private AdminUseCases _adminUseCases;
        public AdminController(UseCases usecases, TransactionPresenter transactionPresenter, UserPresenter userPresenter, AdminUseCases adminUseCases)
        {
            _usecases = usecases;
            _transactionPresenter = transactionPresenter;
            _userPresenter = userPresenter;
            _adminUseCases = adminUseCases;
        }

        // GET /api/admin/users
        [HttpGet("users")]
        public List<User> findAllUsers()
        {
            return _usecases.FindAllUsers();
        }

        [HttpGet("users/populated-users")]
        public List<PopulatedUser> FindAllPopulatedUsers()
        {
            return _userPresenter.FindAllPopulatedUsers();
        }

        
        
        // GET /api/admin/transactions
        [HttpGet("transactions")]
        public List<Transaction> findAllTransactions()
        {
            return _usecases.FindAllTransactions();
        }

        // GET /api/admin/populated-transactions
        [HttpGet("transactions/populated-transactions")]
        public List<PopulatedTransaction> FindAllPopulateTransactions()
        {
            return _transactionPresenter.FindAllPopulatedTransactions(_usecases.FindAllTransactions());
            
        }
        
        // POST /api/admin/transactions/search/{str}
        [HttpGet("transactions/search/{str}")]
        public List<PopulatedTransaction> TransactionsSearching(string str)
        {
            return _transactionPresenter.FindAllPopulatedTransactions(_usecases.TransactionsSearching(str));
        }

            [HttpGet("transactions/populated-transactions/{limit:int}")]
        public List<PopulatedTransaction> FindAllPopulateTransactionsWithLimit(int limit)
        {
            return _transactionPresenter.FindAllPopulatedTransactionsWithLimit(limit);
        }

        [HttpGet("transactions/count")]
        public ActionResult<IEnumerable<TransactionsQuery>> TransactionsCounting()
        {
            TransactionsQuery query = _usecases.TransactionCounting();
            return new []
            {
                query
            };
        }

        [HttpGet("transactions/ef")]
        public List<Transactions> GetAllEfTransactions()
        {
            return _usecases.GetAllEfTransactions();
        }

        [HttpGet("test")]
        public async Task<ActionResult<IEnumerable<Transactions>>> FindAllTransactions()
        {
            return _adminUseCases.FindAllTransactions(1);
        }
    }
}