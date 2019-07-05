using System.Collections.Generic;

namespace AdminDemo.Usecases.Repositories
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        List<T> FindOnePart(int limit, int amount);
        T FindById(string id);
        void Create(T t);
        void Update(T t);
        void Delete(T t);
        
    }
}