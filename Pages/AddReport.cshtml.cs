using ClassManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ClassManager.Pages
{
    public class AddReportModel : PageModel
    {
        [BindProperty]
        public Report Report { get; set; }

        [BindProperty(SupportsGet = true)]
        public int StdId { get; set; }

        public List<Classes> Classes  = new List<Classes>();

        [BindProperty]
        public int ClsId { get; set; }

        public IActionResult OnGet()
        {
            using (AppDbContext dbcontext = new AppDbContext())
            {
                Classes = dbcontext.Student.Where(s => s.Id == StdId).Include(s => s.Classes).FirstOrDefault().Classes.ToList();
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            using (AppDbContext dbcontext = new AppDbContext())
            {
                Report.DataReport = DateTime.Now;
                Report.Students = dbcontext.Student.Where(s => s.Id == StdId).Include(s => s.Classes).FirstOrDefault();
                Report.Classes = dbcontext.Class.Where(c => c.Id == ClsId).Include(s => s.Students).FirstOrDefault();
                dbcontext.Report.Add(Report);
                dbcontext.SaveChanges();
                return RedirectToPage("Index");
            }
        }

    }
}
