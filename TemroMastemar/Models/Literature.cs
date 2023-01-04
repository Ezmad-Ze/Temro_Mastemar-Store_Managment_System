using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemroMastemar.Models
{
    public class Literature
    {
        [Key]
        public int LiteratureID { get; set; }

        [Display(Name = "የፅሁፉ ርዕስ")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉ ርዕስ ያስገቡ")]
        public string LiteratureTitle { get; set; }

        [Display(Name = "የፅሁፉ ዓይነት")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉ ዓይነት ያስገቡ")]
        public string LiteratureType { get; set; } = "የለም";

        [Display(Name = "የፅሁፉ ይዘት")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉ ይዘት ያስገቡ")]
        public string LiteratureFor { get; set; }

        [Display(Name = "የተፃፈበት ወር")]
        public  int? WrittenMonth { get; set; }

        [Display(Name = "የተፃፈበት ዓመተ ምህረት")]
        public int? WrittenYear { get; set; }

        [Display(Name = "የፀሓፊ ስም")]
        [Required(ErrorMessage = "እባክዎ የፀሓፊ ስም ያስገቡ")]
        public int MemberID { get; set; }
        public virtual Member? member { get; set; }

        [Display(Name = "የዶሴዉ ስም")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉን ዶሴ ስም ያስገቡ")]
        public string Physical_Document { get; set; }

        [Display(Name = "ፅሁፉ")]
     
        public string? Document { get; set; } 

        [NotMapped]
        [Display(Name = "ፅሁፉን ይጫኑ")]
        public IFormFile? LiteratureFile { get; set; }
    }
}
