using System.Collections.Generic;

namespace AdminDemo.Usecases.Repositories
{
    public interface ISearchingService<T>
    {
        List<string> SearchString(string str);
    }
}