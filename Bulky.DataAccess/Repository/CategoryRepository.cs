using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public ApplicationDbContext _db;
        
        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        

        public void Update(Category category)
        {
            _db.Category.Update(category);
        }

    }
}
