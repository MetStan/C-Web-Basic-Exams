using Git.Data;
using Git.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Git.Services
{
    public class DBaseService<T> : IDBaseService<T> where T : class
    {

        public DBaseService(ApplicationDbContext data)
        {
            db = data;
        }

        protected  ApplicationDbContext db;

        public void Add(T entity)
        {
            DbSet().Add(entity);
        }

        public IQueryable<T> All()
        {
            return db.Set<T>();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        private DbSet<T> DbSet()
        {
            return db.Set<T>();
        }
    }
}
