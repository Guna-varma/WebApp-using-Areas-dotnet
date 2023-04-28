using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeabApp_Razor.Data;
using WeabApp_Razor.Models;

namespace WeabApp_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> categoryList { get; set; }   
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            categoryList = _db.Category.ToList();
        } 
    }
}
