using BookLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Repositories.Repositories
{
    public class BaseRepository<T, TContext>
        where T : BaseEntity
        where TContext : DbContext, new()
    {

        public virtual TContext Context { get; set; }

        public virtual DbSet<T> Set { get; set; }

        public virtual T Insert(T entity)
        {
            T savedEntity = Set.Add(entity);

            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return savedEntity;
        }

        public virtual T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Set.Attach(entity);
            Set.Remove(entity);
            Context.SaveChanges();
        }

        public virtual void DeleteRange(IQueryable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            Set.RemoveRange(entities);
            Context.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            return Set;
        }

        public virtual T GetById(int id)
        {
            return Set.Where(s => s.Id == id).SingleOrDefault();
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            T savedEntity = Set.Add(entity);

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return savedEntity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Set.Attach(entity);
            Set.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(IQueryable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            Set.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await Set.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Set.Where(s => s.Id == id).SingleOrDefaultAsync();
        }



        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

    }
}
