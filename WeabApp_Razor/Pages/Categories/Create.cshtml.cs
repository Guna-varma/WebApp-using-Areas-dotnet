using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeabApp_Razor.Data;
using WeabApp_Razor.Models;

namespace WeabApp_Razor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost(Category category) 
        { 
            _db.Category.Add(category);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully!";
            return RedirectToPage("Index");
        }
        
    }
}
