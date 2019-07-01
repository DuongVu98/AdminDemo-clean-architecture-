using System.Collections.Generic;

namespace AdminDemo.Usecases.Repositories
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        T FindById(string id);
        void Create(T t);
        void Update(T t);
        void Delete(T t);
    }
}