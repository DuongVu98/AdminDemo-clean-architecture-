using System.Collections.Generic;
using AdminDemo.Adapters.Models;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.Interactors;

namespace AdminDemo.Adapters.Presenters
{
    public class UserPresenter
    {
        private UseCases _usecases;

        public UserPresenter(UseCases usecases)
        {
            _usecases = usecases;
        }

        public List<PopulatedUser> FindAllPopulatedUsers()
        {
            List<PopulatedUser> populatedUsers = new List<PopulatedUser>();

            List<User> users = _usecases.FindAllUsers();
            foreach (var user in users)
            {
                Province province = _usecases.FindProviceById(user.ProvinceId);
                
                PopulatedUser populatedUser = new PopulatedUser(user.Id, user.Username, user.Password, user.FirstName, user.LastName, user.BirthDate, user.Address, province);
                populatedUsers.Add(populatedUser);
            }
            
            return populatedUsers;
        }
    }
}