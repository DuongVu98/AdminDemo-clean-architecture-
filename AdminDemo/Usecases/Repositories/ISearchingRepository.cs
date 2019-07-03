using System.Collections.Generic;

namespace AdminDemo.Usecases.Repositories
{
    public interface ISearchingRepository<T>
    {
        List<T> SearchString(string str);
    }
}