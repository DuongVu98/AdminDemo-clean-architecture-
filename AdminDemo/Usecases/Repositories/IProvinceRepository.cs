using System.Collections.Generic;
using AdminDemo.Domains.Entities;

namespace AdminDemo.Usecases.Repositories
{
    public interface IProvinceRepository
    {
        List<Province> findAll();
        Province findById(string id);
        void Create(Province province);
        void Update(Province province);
        void Delete(Province province);
    }
}