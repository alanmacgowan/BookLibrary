using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Repositories.Abstract
{

    public interface IRepository<T>
    {
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IQueryable<T> entities);
        IQueryable<T> GetAll();
        T GetById(int id);

        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IQueryable<T> entities);
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }

}
