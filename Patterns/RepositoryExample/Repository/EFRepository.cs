using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryExample.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RepositoryExample.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;

        public Repository(DbContext context) 
        {
            _entities = context.Set<T>();
        }

        public int Count(Func<T, bool> predicate)
        {
            return _entities.Count(predicate);
        }

        public void Create(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _entities.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Update(T entity)
        {
            _entities.Attach(entity).State = EntityState.Modified;

        }
    }
}