using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TemroMastemar.Models
{
    public class Audio
    {
        [Key]
        public int AudioID { get; set; }

        [Display(Name = "የድምፁ ርዕስ")]
        [Required(ErrorMessage = "እባክዎ የድምፁን ርዕስ ያስገቡ")]
        public string AudioTitle { get; set; }

        [Display(Name = "የድምፁ ዓይነት")]
        [Required(ErrorMessage = "እባክዎ የድምፁን ዓይነት ያስገቡ")]
        public string AudioType { get; set; }

        [Display(Name = "የድምፁ ይዘት")]
        public string? AudioFor { get; set; }

        [Display(Name = "ቀን")]
        public int? AudioDate { get; set; }

        [Display(Name = "ወር")]
        public int? AudioMonth { get; set; }

        [Display(Name = "ዓመተ ምህረት")]
        [Required(ErrorMessage = "እባክዎ ዓመተ ምህረት ያስገቡ")]
        public int AudioYear { get; set; } = 2001;

        [Display(Name = "የድምፁ ባለቤት")]
        [Required(ErrorMessage = "እባክዎ የድምፁን ባለቤት ያስገቡ")]
        public string AudioBy { get; set; }


        [Display(Name = "ድምፁ የተቀመጠበት ቦታ")]
        public string? Path { get; set; }


        [NotMapped]
        public string? Month_and_Year
        {
            get
            {
                return this.AudioMonth + "/" + this.AudioYear + "ዓ.ም";
            }
        }
        [NotMapped]
        public string? _Year
        {
            get
            {
                return this.AudioYear + " ዓ.ም";
            }
        }
    }
}

