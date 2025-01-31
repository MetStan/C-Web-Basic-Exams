﻿namespace SharedTrip.Data.Common
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class Repository : IRepository
    {
        protected DbContext db;

        public Repository(ShareTripDbContext data)
        {
            db = data;
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return db.Set<T>();
        }
    }
}
