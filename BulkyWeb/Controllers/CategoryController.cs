
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BulkyWeb.Areas.Admin.Controllers
{
    //[Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork repo;

        public CategoryController(IUnitOfWork categoryRepository)
        {
            repo = categoryRepository;
        }

        public IActionResult Index()
        {
            List<Category> categories = repo.Category.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())  //custom validation
            {
                ModelState.AddModelError("name", "DisplayOrder cannot not match with CategoryName");
            }

            if (ModelState.IsValid) //validations
            {
                repo.Category.Add(category); // add category 
                repo.Save(); //save
                TempData["success"] = "Category Created Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            Category categoryFromDb = repo.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid) //validations
            {
                repo.Category.Update(category);// add category 
                repo.Save(); //save
                TempData["success"] = "Category Updated Successfully!";

                return RedirectToAction("Index"); // add the data into db
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            Category categoryFromDb = repo.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = repo.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound("Id:" + id + ", is not Found");
            }
            repo.Category.Remove(obj);
            repo.Save();  //save
            TempData["success"] = "Category Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}