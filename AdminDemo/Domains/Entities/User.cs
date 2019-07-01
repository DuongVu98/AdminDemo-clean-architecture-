using System;

namespace AdminDemo.Domains.Entities
{
    public class User
    {
        private string id;
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private string address;
        private string provinceId;

        public User()
        {
        }

        public User(string id, string username, string password, string firstName, string lastName, DateTime birthDate, string address, string provinceId)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.address = address;
            this.provinceId = provinceId;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public string ProvinceId
        {
            get => provinceId;
            set => provinceId = value;
        }
    }
}