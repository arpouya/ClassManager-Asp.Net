using ClassManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ClassManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Students> StudentsL { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                StudentsL = dbContext.Student.Include(s => s.Classes).OrderByDescending(s => s.DateCreate).ToList();
            }
        }
    }
}