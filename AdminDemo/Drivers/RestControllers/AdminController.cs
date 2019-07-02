using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AdminDemo.Adapters.Models;
using AdminDemo.Adapters.Presenters;
using AdminDemo.Domains.Entities;
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

        public AdminController(UseCases usecases, TransactionPresenter transactionPresenter, UserPresenter userPresenter)
        {
            _usecases = usecases;
            _transactionPresenter = transactionPresenter;
            _userPresenter = userPresenter;
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
            return _transactionPresenter.FindAllPopulatedTransactions();
            
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
//                new Count
//                {
//                    Thiscount = count
//                }
//                new TransactionsQuery
//                {
//                    TransactionsPerQuery = query.TransactionsPerQuery,
//                    NumberOfAllTransactions = query.NumberOfAllTransactions
//                }
                query
            };
        }

    }
}