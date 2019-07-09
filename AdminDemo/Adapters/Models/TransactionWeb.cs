using System.Collections.Generic;
using AdminDemo.Domains.Models;

namespace AdminDemo.Adapters.Models
{
    public class TransactionWeb
    {
        private List<Transactions> list;
        private int count;

        public TransactionWeb()
        {
        }

        public TransactionWeb(List<Transactions> transactions, int count)
        {
            this.list = transactions;
            this.count = count;
        }

        public List<Transactions> Transactions
        {
            get => list;
            set => list = value;
        }

        public int Count
        {
            get => count;
            set => count = value;
        }
    }
}