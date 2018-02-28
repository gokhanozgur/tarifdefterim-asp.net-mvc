using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;
using TarifDefterim.Core.Enum;
using TarifDefterim.Core.Service;
using TarifDefterim.DAL.Context;

namespace TarifDefterim.Service.BaseService
{
    public class MainService<T> : ICoreService<T> where T : CoreEntity
    {

        private static ProjectContext _dbContext;

        public ProjectContext dbContext
        {

            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new ProjectContext();
                    return _dbContext;
                }
                return _dbContext;
            }
            set
            {
                _dbContext = value;
            }

        }

        public void Add(T item)
        {
            dbContext.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            dbContext.Set<T>().AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return dbContext.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return dbContext.Set<T>().Where(x => x.Status == Status.Active || x.Status == Status.Updated).ToList();
        }

        public List<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return dbContext.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetByID(Guid id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public List<T> GetByExp(Expression<Func<T, bool>> exp)
        {
            return dbContext.Set<T>().Where(exp).ToList();
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            Update(item);
        }

        public void Remove(Guid id)
        {
            T item = GetByID(id);
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetByExp(exp))
            {
                item.Status = Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public void Update(T item)
        {
            T update = GetByID(item.ID);
            DbEntityEntry entry = dbContext.Entry(update);
            entry.CurrentValues.SetValues(item);
            Save();
        }
    }
}
