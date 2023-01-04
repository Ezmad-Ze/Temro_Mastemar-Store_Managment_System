using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TemroMastemar.Models
{
    public class Video
    {
        [Key] 
        public int VideoID { get; set; }

        [Display(Name = "የምስሉ ርዕስ")]
        [Required(ErrorMessage = "እባክዎ የምስሉን ርዕስ ያስገቡ")]
        public string VideoTitle { get; set; }

        [Display(Name = "የምስሉ ዓይነት")]
        [Required(ErrorMessage = "እባክዎ የምስሉን ዓይነት ያስገቡ")]
        public string VideoType { get; set; }

        [Display(Name = "የምስሉ ይዘት")]
        public string? VideoFor { get; set; }

        [Display(Name = "ቀን")]
        public int? VideoDate { get; set; }

        [Display(Name = "ወር")]
        public int? VideoMonth { get; set; } 

        [Display(Name = "ዓመተ ምህረት")]
        [Required(ErrorMessage = "እባክዎ ዓመተ ምህረት ያስገቡ")]
        public int VideoYear { get; set; } = 2001;

        [Display(Name = "የምስሉ ባለቤት")]
        [Required(ErrorMessage = "እባክዎ የምስሉን ባለቤት ያስገቡ")]
        public string VideoBy { get; set; }


        [Display(Name = "የምስሉ የተቀመጠበት ቦታ")]
        public string? Path { get; set; }

        [NotMapped]
        public string? Month_and_Year
        {
            get
            {
                return this.VideoMonth + "/" + this.VideoYear + "ዓ.ም";
            }
        }
        [NotMapped]
        public string? _Year
        {
            get
            {
                return this.VideoYear + " ዓ.ም";
            }
        }
    }
}

