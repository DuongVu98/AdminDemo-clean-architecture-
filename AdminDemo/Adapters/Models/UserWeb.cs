using System.Collections.Generic;
using AdminDemo.Domains.Models;

namespace AdminDemo.Adapters.Models
{
    public class UserWeb
    {
        private List<Users> users;
        private int count;

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
    }
}