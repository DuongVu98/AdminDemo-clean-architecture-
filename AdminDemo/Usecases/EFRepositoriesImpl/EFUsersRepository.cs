using System.Collections.Generic;
using System.Linq;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdminDemo.Usecases.EFRepositoriesImpl
{
    public class EFUsersRepository : IUserRepository
    {
        private mydbContext context =new mydbContext();
        private int amount = AppSetting.UsersPerQuery;
        
        public List<Users> FindAll()
        {
            return context.Users.ToList();
        }

        public List<Users> FindAll(int limit)
        {
            return context.Users.Skip(limit).Take(amount).ToList();
        }

        public int Count()
        {
            return context.Users.Count();
        }

        public Users FindById(string id)
        {
            return context.Users.Single(u => u.Id == id);
        }

        public List<Users> FindByProvinceId(string id)
        {
            return context.Users.Where(u => u.ProvincesId == id).ToList();
        }

        public List<Users> FindByProvinceId(string id, int limit)
        {
            return context.Users.Where(u => u.ProvincesId == id).Skip(limit).Take(amount).ToList();
        }

        public int CountFindByProvinceId(string id)
        {
            return context.Users.Where(u => u.ProvincesId == id).Count();
        }

        public List<Users> FindByCountryId(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Users> FindByCountryId(string id, int limit)
        {
            throw new System.NotImplementedException();
        }

        public int CountFindByCountryId(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Users> SearchByUserName(string userName)
        {
            string str = "%" + userName + "%";
            return context.Users.Where(u => EF.Functions.Like(u.UserName, str)).ToList();
        }

        public List<Users> SearchByUserName(string userName, int limit)
        {
            string str = "%" + userName + "%";
            return context.Users.Where(u => EF.Functions.Like(u.UserName, str)).Skip(limit).Take(amount).ToList();
        }

        public int CountSearchByUserName(string userName)
        {
            string str = "%" + userName + "%";
            return context.Users.Where(u => EF.Functions.Like(u.UserName, str)).Count();
        }

        public List<Users> SearchByProvinceName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public List<Users> SearchByProvinceName(string userName, int limit)
        {
            throw new System.NotImplementedException();
        }

        public int CountSearchByProvinceName(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}