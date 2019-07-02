namespace AdminDemo.Usecases.Interactors
{
    public class TransactionsQuery
    {
        private int transactionsPerQuery;
        private int numberOfAllTransactions;

        public TransactionsQuery()
        {
        }

        public TransactionsQuery(int transactionsPerQuery, int numberOfAllTransactions)
        {
            this.transactionsPerQuery = transactionsPerQuery;
            this.numberOfAllTransactions = numberOfAllTransactions;
        }

        public int TransactionsPerQuery
        {
            get => transactionsPerQuery;
            set => transactionsPerQuery = value;
        }

        public int NumberOfAllTransactions
        {
            get => numberOfAllTransactions;
            set => numberOfAllTransactions = value;
        }
    }
}