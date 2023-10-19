using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClassManager.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Display(Prompt = "Example : Ali")]
        public string Firstname { get; set; }

        [Display(Prompt = "Example : Ahmadi")]
        public string Lastname { get; set; }

        [Display(Prompt = "Example : Mohammadi")]
        public string Fathername { get; set; }

        [Display(Prompt = "Example : 10")]
        public int Grade { get; set; }

        [Display(Prompt = "Example : 0151501515")]
        public string Code { get; set; }

        [Display(Prompt = "Example : 15")]
        public int Age { get; set; }

        public DateTime DateCreate { get; set; }

        public List<Classes>? Classes { get; set; }



    }
}
