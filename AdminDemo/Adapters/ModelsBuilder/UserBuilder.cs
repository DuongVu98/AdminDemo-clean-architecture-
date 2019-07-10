using System.Collections.Generic;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Interactors;
using AdminDemo.Usecases.Repositories;

namespace AdminDemo.Adapters.ModelsBuilder
{
    public class UserBuilder
    {
        private AdminUseCases _adminUseCases;

        public UserBuilder(AdminUseCases adminUseCases)
        {
            _adminUseCases = adminUseCases;
        }

        public Users Build(Users user)
        {
            user.Provinces = _adminUseCases.FindProvinceById(user.ProvincesId);

            return user;
        }

        public List<Users> ListBuild(List<Users> users)
        {
            foreach (var user in users)
            {
                user.Provinces = _adminUseCases.FindProvinceById(user.ProvincesId);
            }

            return users;
        }
    }
}