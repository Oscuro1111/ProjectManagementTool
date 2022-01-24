using System.Collections.Generic;
using DataLayer.Model;
namespace PMSRepository
{
    public interface IPMSRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long Id);

        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);

        void SaveChanges();
    }
}
