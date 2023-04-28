using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeabApp_Razor.Data;
using WeabApp_Razor.Models;

namespace WeabApp_Razor.Pages.Categories
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category category { get; set; }
        public UpdateModel(ApplicationDbContext db)
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
            if (ModelState.IsValid) //validations
            {
                _db.Category.Update(category); // add category 
                _db.SaveChanges(); //save
                TempData["success"] = "Category Updated Successfully!";
                return RedirectToPage("Index"); // add the data into db
            }
            return Page();
        }
    }
}
