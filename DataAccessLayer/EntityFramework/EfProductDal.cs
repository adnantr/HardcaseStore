using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetProductsListWithCategory()
        {
           using(var c=new ApplicationDbContext())
            {
                return c.Products.Include(x=>x.Categories).ToList();

            }
        }

        public List<Product> GetProductsWithCategory()
        {
            using (var c = new ApplicationDbContext())
            {
                return c.Products.Include(x => x.Categories.Name).Distinct().ToList();
            }
        }

    }
}
