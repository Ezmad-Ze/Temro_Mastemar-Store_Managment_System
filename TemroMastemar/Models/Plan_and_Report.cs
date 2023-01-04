using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemroMastemar.Models
{
    public class Plan_and_Report
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "የሚገባው ፅሁፍ")]
        [Required(ErrorMessage = "እባክዎ የሚገባው ፅሁፍ ያስገቡ")]
        public string Plan_or_Report { get; set; }  

        [Display(Name = "ርዕስ")]
        [Required(ErrorMessage = "እባክዎ ርዕስ ያስገቡ")]
        public string Title { get; set; }

        [Display(Name = "ዓይነት")]
        [Required(ErrorMessage = "እባክዎ ዓይነት ያስገቡ")]
        public string Type { get; set; } = "የለም";

        [Display(Name = "ቀን")]
        public int? S_ReportDate { get; set; }

        [Display(Name = "ወር")]
        [Required(ErrorMessage = "እባክዎ ወር ያስገቡ")]
        public int S_ReportMonth { get; set; } = 01;

        [Display(Name = "ዓመተ ምህረት")]
        [Required(ErrorMessage = "እባክዎ ዓመተ ምህረት ያስገቡ")]
        public int S_ReportYear { get; set; } = 2000;

        [Display(Name = "ቀን")]
        public int? E_ReportDate { get; set; }

        [Display(Name = "ወር")]
        [Required(ErrorMessage = "እባክዎ ወር ያስገቡ")]
        public int E_ReportMonth { get; set; } = 01;

        [Display(Name = "ዓመተ ምህረት")]
        [Required(ErrorMessage = "እባክዎ ዓመተ ምህረት ያስገቡ")]
        public int E_ReportYear { get; set; } = 2001;

        [Display(Name = "የፃፈው አካል")]
        [Required(ErrorMessage = "እባክዎ የፃፈው አካል ያስገቡ")]
        public string ReportBy { get; set; }

        [Display(Name = "የዶሴዉ ስም")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉን ዶሴ ስም ያስገቡ")]
        public string Physical_Document { get; set; }

        [Display(Name = "ፅሁፉ")]

        public string? Document { get; set; }

        [NotMapped]
        [Display(Name = "ፅሁፉን ይጫኑ")]
        public IFormFile? File { get; set; }

        [NotMapped]
        public string? E_Month_and_Year
        {
            get
            {
                return this.E_ReportMonth + "/" + this.E_ReportYear + "ዓ.ም";
            }
        }
        [NotMapped]
        public string? S_Month_and_Year
        {
            get
            {
                return this.S_ReportMonth + "/" + this.S_ReportYear + "ዓ.ም";
            }
        }
    }
}
