using GamesForFree.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesForFree.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> All { get; }
        void Delete(TEntity entity);
        void Create(TEntity entity);
        void Update(TEntity entity);
    }
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly GamesForFreeDbContext _databaseContext;

        public IQueryable<TEntity> All => _databaseSet;

        private DbSet<TEntity> _databaseSet => _databaseContext.Set<TEntity>();

        public GenericRepository(GamesForFreeDbContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public void Delete(TEntity entity)
        {
            _databaseSet.Remove(entity);
        }
        public void Create(TEntity entity)
        {
            _databaseSet.Add(entity);
        }
        public void Update(TEntity entity)
        {
            _databaseSet.Update(entity);
        }


    }
}
