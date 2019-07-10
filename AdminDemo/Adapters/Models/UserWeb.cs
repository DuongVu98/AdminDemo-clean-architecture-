using System.Collections.Generic;
using AdminDemo.Domains.Models;

namespace AdminDemo.Adapters.Models
{
    public class UserWeb
    {
        private List<Users> users;
        private int count;
        private int amountPerPage = 5;
        
        
        public List<Users> Users
        {
            get => users;
            set => users = value;
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
