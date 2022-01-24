using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using PMSRepository.Context;

namespace PMSRepository
{
    class Utility<T> where T:class{ 
         public static  bool IsNULL(T obj)
        {
            return obj == null;
        }
    }

   public class PMSRepository<T> : IPMSRepository<T> where T : BaseEntity
    {

        private readonly DbContext context;
        private readonly DbSet<T> entites;
        public PMSRepository(PMSContext context)
        {
            this.context = context;
            this.entites = context.Set<T>();
        }
        public void Delete(T entity)
        {
            if (Utility<T>.IsNULL(entity))
            {
                throw new System.ArgumentNullException("entity is null.");
            }

            entites.Remove(entity);
            SaveChanges();

        }

        public T Get(long Id)
        {
            return entites.SingleOrDefault(entity=>entity.Id==Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entites.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (Utility<T>.IsNULL(entity))
            {
                throw  new System.ArgumentNullException("entity is null");
            }

            entites.Add(entity);

            SaveChanges();

        }

        public void SaveChanges()
        {
            if (Utility<DbContext>.IsNULL(context))
            {
                throw new System.ArgumentNullException("context is null");
            }

            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (Utility<T>.IsNULL(entity))
            {
                throw new System.ArgumentNullException("entity is null.");
            }

            SaveChanges();
        }

    }
}
