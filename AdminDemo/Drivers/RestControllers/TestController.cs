using System.Collections.Generic;
using System.Threading.Tasks;
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

        public TestController(AdminUseCases adminUseCases, TransactionBuilder transactionBuilder)
        {
            _adminUseCases = adminUseCases;
            _transactionBuilder = transactionBuilder;
        }

        [HttpGet("transactions")]
        public async Task<ActionResult<IEnumerable<Transactions>>> FindAllTransactions()
        {

            return _transactionBuilder.ListBuild(_adminUseCases.FindAllTransactions(0));
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<Users>>> FindAllUsers()
        {
            return _adminUseCases.FindAllUsers(0);
        }
    }
}