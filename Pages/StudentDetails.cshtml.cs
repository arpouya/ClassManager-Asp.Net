using ClassManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ClassManager.Pages
{
    public class StudentDetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        public Students Students { get; set; }

        public List<Report> Report = new List<Report>();

        public void OnGet()
        {

            using (AppDbContext dbcontext = new AppDbContext())
            {

                Students = dbcontext.Student.Where(s => s.Id == id).Include(s => s.Classes).FirstOrDefault();
                Report = dbcontext.Report.Where(r => r.Students.Id == id).ToList();
            }

        }

        public void OnPost()
        {

            using(AppDbContext dbcontext = new AppDbContext())
            {
                Students = dbcontext.Student.Where(s => s.Id == id).Include(s => s.Classes).FirstOrDefault();
                dbcontext.Student.Remove(Students);
                dbcontext.SaveChanges();
                Response.Redirect("Index");
            }

        }
    }
}
