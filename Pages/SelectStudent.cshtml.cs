using ClassManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassManager.Models;

namespace ClassManager.Pages
{
    public class SelectStudentModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int StdId { get; set; }
        public List<Students> StudentsL = new List<Students>();
        public void OnGet()
        {

            using (AppDbContext dbcontext = new AppDbContext())
            {
                StudentsL = dbcontext.Student.Include(s => s.Classes).ToList();
            }
            if(StdId != 0)
            {
                string Link = "./AddReport?StdId=" + StdId;
                Response.Redirect(Link);
            }

        }
    }
}
