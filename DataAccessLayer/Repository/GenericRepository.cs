using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new ApplicationDbContext();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new ApplicationDbContext();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var c = new ApplicationDbContext();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var c = new ApplicationDbContext();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new ApplicationDbContext();
            c.Update(t);
            c.SaveChanges();
        }

    }
}
