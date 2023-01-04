using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemroMastemar.Models
{
    public class Form
    {
        [Key]
        public int FormID { get; set; }

        [Display(Name = "የቅፁ ርዕስ")]
        [Required(ErrorMessage = "እባክዎ የቅፁ ርዕስ ያስገቡ")]
        public string FormTitle { get; set; }

        [Display(Name = "ቀን")]
        public int? FormDate { get; set; }

        [Display(Name = "ወር")]
        public int? FormMonth { get; set; }

        [Display(Name = "ዓመተ ምህረት")]
        public int? FormYear { get; set; }

        [Display(Name = "የቅፁ አውጪ")]
        [Required(ErrorMessage = "እባክዎ የቅፁ አውጪ ያስገቡ")]
        public string FormBy { get; set; }

        [Display(Name = "የዶሴዉ ስም")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉን ዶሴ ስም ያስገቡ")]
        public string Physical_Document { get; set; }

        [Display(Name = "ፅሁፉ")]
        public string? Document { get; set; }

        [NotMapped]
        [Display(Name = "ፅሁፉን ይጫኑ")]
        public IFormFile? FormFile { get; set; }
    }
}
