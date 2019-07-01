using System.Collections.Generic;
using AdminDemo.Domains.Entities;

namespace AdminDemo.Usecases.Repositories
{
    public interface IUserRepository
    {
        List<User> FindAll();
        User FindById(string id);
        void Create(User user);
        void Update(User user);
        void DeleteById(string id);
    }
}