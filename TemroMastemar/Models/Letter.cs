using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemroMastemar.Models
{
    public class Letter
    {
        [Key]
        public int LetterID { get; set; }

        [Display(Name = "የደብዳቤው ርዕስ")]
        [Required(ErrorMessage = "እባክዎ የደብዳቤውን ርዕስ ያስገቡ")]
        public string LetterTitle { get; set; }

        [Display(Name = "የደብዳቤው ዓይነት")]
        public string? LetterType { get; set; } 

        [Display(Name = "ቀን")]
        public int? S_LetterDate { get; set; }

        [Display(Name = "ወር")]
        [Required(ErrorMessage = "እባክዎ ወር ያስገቡ")]
        public int S_LetterMonth { get; set; } = 01;

        [Display(Name = "ዓመተ ምህረት")]
        [Required(ErrorMessage = "እባክዎ ዓመተ ምህረት ያስገቡ")]
        public int S_LetterYear { get; set; } = 2001;

        [Display(Name = "ላኪው")]
        [Required(ErrorMessage = "እባክዎ ደብዳቤው ከማን እንደሆነ ያስገቡ")]
        public string From { get; set; }

        [Display(Name = "ተቀባይ")]
        [Required(ErrorMessage = "እባክዎ ደብዳቤው ለማን እንደሆነ ያስገቡ")]
        public string To { get; set; }

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
                return this.S_LetterMonth + "/" + this.S_LetterYear + "ዓ.ም";
            }
        }
    }
}
