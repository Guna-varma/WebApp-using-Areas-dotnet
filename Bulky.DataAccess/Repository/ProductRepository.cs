using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product product)
        {
            var productFromDb = _db.products.FirstOrDefault(u=>u.Id == product.Id);
            if (productFromDb != null)
            {
                productFromDb.Title = product.Title;
                productFromDb.Description = product.Description;
                productFromDb.ISBN = product.ISBN;
                productFromDb.Price = product.Price;
                productFromDb.Price100 = product.Price100;
                productFromDb.Price50 = product.Price50;
                productFromDb.CategoryId = product.CategoryId;
                productFromDb.Author = product.Author;
                if(product.ImageURL != null )
                {
                    productFromDb.ImageURL = product.ImageURL;
                }
            }
        }

    }
}
