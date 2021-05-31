using System.Collections.Generic;

namespace CadastroDeSeries.Interfaces
{
    interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Create(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}
