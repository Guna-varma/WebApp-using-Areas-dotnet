
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Model.Models;
using Bulky.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork repo;
        private readonly IWebHostEnvironment env;

        public ProductController(IUnitOfWork ProductRepository, IWebHostEnvironment webHostEnvironment)
        {
            repo = ProductRepository;
            env = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> products = repo.Product.GetAll().ToList();
            return View(products);
        }

        public IActionResult Upsert(int? id)  // combining of 'Update' and 'Insert'.
        {
            ProductVM productVM = new()
            {
             CategoryList = repo.Category.GetAll().Select(u => new SelectListItem
             {
                 Text = u.Name,
                 Value = u.Id.ToString()
             }),
                Product = new Product()
            };
            if(id==null || id == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = repo.Product.Get(u => u.Id == id);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {

            if (ModelState.IsValid) //validations
            {
                string wweRootPath = env.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wweRootPath, @"images\product");

                    using(var fileStream = new FileStream(Path.Combine(productPath,fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageURL = @"\images\product"+fileName;
                }

                repo.Product.Add(productVM.Product); // add Product 
                repo.Save(); //save
                TempData["success"] = "Product Created Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                productVM.CategoryList = repo.Category.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                return View(productVM);
            }
        }

        /*
        public IActionResult Create()
        {
            ProductVM productVM = new()
            {
                CategoryList = repo.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {

            if (ModelState.IsValid) //validations
            {
                repo.Product.Add(productVM.Product); // add Product 
                repo.Save(); //save
                TempData["success"] = "Product Created Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                productVM.CategoryList = repo.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
        } 
        */
        
        
        /* public IActionResult Edit(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            Product ProductFromDb = repo.Product.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(ProductFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product Product)
        {
            if (ModelState.IsValid) //validations
            {
                repo.Product.Update(Product);// add Product 
                repo.Save(); //save
                TempData["success"] = "Product Updated Successfully!";

                return RedirectToAction("Index"); // add the data into db
            }
            return View();
        }
         */

        public IActionResult Delete(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            Product ProductFromDb = repo.Product.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(ProductFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = repo.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound("Id:" + id + ", is not Found");
            }
            repo.Product.Remove(obj);
            repo.Save();  //save
            TempData["success"] = "Product Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}