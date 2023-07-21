using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public List<Category> GetProductsWithCategoryNoAgain()
        {
            using (var c = new ApplicationDbContext())
            {
                return c.Categories.GroupBy(x => x.Name).Select(i => i.First()).Distinct().ToList();
            }
        }
    }
}
