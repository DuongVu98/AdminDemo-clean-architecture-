using System.Collections.Generic;
using AdminDemo.Domains.Models;

namespace AdminDemo.Adapters.Models
{
    public class TransactionWeb
    {
        private List<Transactions> transactions;
        private int count;
        private int amountPerPage = AppSetting.TransactionsPerQuery;

        public TransactionWeb()
        {
        }

        public TransactionWeb(List<Transactions> transactions, int count)
        {
            this.transactions = transactions;
            this.count = count;
        }

        public List<Transactions> Transactions
        {
            get => transactions;
            set => transactions = value;
        }

        public int Count
        {
            get => count;
            set => count = value;
        }

        public int AmountPerPage
        {
            get => amountPerPage;
            set => amountPerPage = value;
        }
    }
}