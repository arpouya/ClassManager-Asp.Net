using ClassManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace ClassManager.Pages
{
    public class AddStudentModel : PageModel
    {
        [BindProperty]
        public Students Students { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }


        public void OnGet()
        {

            using (AppDbContext dbcontext = new AppDbContext())
            {
                Students = dbcontext.Student.Where(s =>s.Id == Id).Include(s => s.Classes).FirstOrDefault();
            }

        }

        public IActionResult OnPost()
        {

            using (AppDbContext dbcontext = new AppDbContext())
            {

                Students.Id = Id;
                Students.DateCreate = DateTime.Now;
                dbcontext.Student.Update(Students);
                dbcontext.SaveChanges();

            }

            return RedirectToPage("Index");

        }
    }
}
