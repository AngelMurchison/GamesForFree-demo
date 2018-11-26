using GamesForFree.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesForFree.Data
{
    public interface IUnitOfWork
    {
        IRepository<CompanyVideoGame> companyVideoGameRepository { get; }
        IRepository<VideoGame> videoGameRepository { get; }
        IRepository<Company> companyRepository { get; }
        IRepository<User> userRepository { get; }

        void RejectChanges();
        void Dispose();
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly GamesForFreeDbContext _databaseContext;
        
        public IRepository<CompanyVideoGame> companyVideoGameRepository =>
            new GenericRepository<CompanyVideoGame>(_databaseContext);

        public IRepository<VideoGame> videoGameRepository =>
           new GenericRepository<VideoGame>(_databaseContext);

        public IRepository<Company> companyRepository =>
           new GenericRepository<Company>(_databaseContext);

        public IRepository<User> userRepository =>
            new GenericRepository<User>(_databaseContext);

        public UnitOfWork(GamesForFreeDbContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public void Commit()
        {
            _databaseContext.SaveChanges();
        }
        public void Dispose()
        {
            _databaseContext.Dispose();
        }
        public void RejectChanges()
        {
            foreach (var entry in _databaseContext.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
