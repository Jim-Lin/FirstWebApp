namespace FirstWebApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using Nancy;
    using NLog;

    public abstract class AppService<T> where T : class
    {
        private DbContext entities;
        private DbSet<T> entity;

        public AppService(DbContext entities)
        {
            this.entities = entities;
            this.entity = entities.Set<T>();
        }

        public DbSet<T> Entity
        {
            get
            {
                return this.entity;
            }
        }

        public IList<T> FindRecords()
        {
            return this.entity.Cast<T>().ToList<T>();
        }

        public void SaveChanges()
        {
            this.entities.SaveChanges();
        }

        public virtual T GetRecordByName(string name)
        {
            return null;
        }

        public virtual T GetRecordById(int id)
        {
            return null;
        }

        public virtual void AddRecord(T obj)
        {
        }

        public virtual void UpdateRecord(T obj)
        {
        }

        public virtual void DeleteRecord(T obj)
        {
        }
    }
}