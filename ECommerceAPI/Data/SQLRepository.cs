﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Data
{
    public class SQLRepository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeContext _databaseContext;

        private readonly DbSet<T> _databaseEntities;
        public SQLRepository(EmployeeContext databaseContext)
        {
            _databaseContext = databaseContext;
            _databaseEntities = databaseContext.Set<T>();
        }
        public void Add(T entity)
        {
            _databaseEntities.Add(entity);
            _databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = _databaseEntities.Find(id);
            _databaseEntities.Remove(entity);
            _databaseContext.SaveChanges();
        }

        public T Get(int id)
        {
            return _databaseEntities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _databaseEntities.AsEnumerable();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _databaseContext.Entry(entity).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
    }
}
