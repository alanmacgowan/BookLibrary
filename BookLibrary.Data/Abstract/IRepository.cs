using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Abstract
{

    public interface IRepository<T>
    {
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IQueryable<T> entities);
        IQueryable<T> GetAll();
        T GetById(int id);
    }

}
