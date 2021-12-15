using System;
using System.Collections.Generic;

namespace ZPMini.Data.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        void Delete(Guid id);
        IEnumerable<TEntity> GetAll();
        TEntity Get(Guid id);
        void Add(TEntity entity);
        void Update(TEntity entity);
    }
}
