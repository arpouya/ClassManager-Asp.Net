using System.ComponentModel.DataAnnotations;

namespace ClassManager.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Display(Prompt = "Example : 20")]
        public int Point { get; set; }
        public DateTime DataReport { get; set; }
        public Students Students { get; set; }
        public Classes Classes { get; set; }
    }
}
