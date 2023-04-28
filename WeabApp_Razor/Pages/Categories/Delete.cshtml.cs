using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeabApp_Razor.Data;
using WeabApp_Razor.Models;

namespace WeabApp_Razor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                category = _db.Category.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = _db.Category.Find(category.Id);
            if (obj == null)
            {
                return NotFound("Id is not Found");
            }
            _db.Category.Remove(obj);
            _db.SaveChanges(); //save
            TempData["success"] = "Category Deleted Successfully!";

            return RedirectToPage("Index");
        }
    }
}
