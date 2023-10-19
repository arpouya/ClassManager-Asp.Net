using ClassManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ClassManager.Pages
{
    public class AddToClassModel : PageModel
    {
        [BindProperty]
        public int StdId { get; set; }
        [BindProperty]
        public int ClsId { get; set; }
        public List<Students> students = new List<Students>();
        public List<Classes> classes = new List<Classes>();

        public void OnGet()
        {
            using (AppDbContext dbcontext = new AppDbContext())
            {
                students = dbcontext.Student.Include(s => s.Classes).ToList();
                classes = dbcontext.Class.Include(c => c.Students).ToList();
            }
        }

        public IActionResult OnPost()
        {

            using (AppDbContext dbContext = new AppDbContext())
            {
                var _std = dbContext.Student.Where(s => s.Id == StdId).Include(s => s.Classes).FirstOrDefault();
                var _cls = dbContext.Class.Where(c => c.Id == ClsId).Include(c => c.Students).FirstOrDefault();
                _cls.Studentsnumber = _cls.Students.Count();
                _cls.Students.Add(_std);
                _std.Classes.Add(_cls);
                dbContext.SaveChanges();
            }

            return RedirectToPage("Index");

        }
    }
}
