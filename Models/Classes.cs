using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace ClassManager.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }

        [Display(Prompt = "Example : Math")]
        public string Classname { get; set; }

        [Display(Prompt = "Example : Ahmad")]
        public string Teachername { get; set; }

        [Display(Prompt = "Example : 20")]
        public int Studentsnumber { get; set; }

        [Display(Prompt = "Example : 2")]
        public int ClassDate { get; set; }

        public List<Students>? Students { get; set; }

    }
}
