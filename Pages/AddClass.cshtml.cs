using ClassManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace ClassManager.Pages
{
    public class AddClassModel : PageModel
    {

        [BindProperty]
        public Classes Classes { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            
            using(AppDbContext dbcontext = new AppDbContext())
            {
                dbcontext.Class.Add(Classes);
                dbcontext.SaveChanges();
            }

            return RedirectToPage("Index");

        }
    }
}
