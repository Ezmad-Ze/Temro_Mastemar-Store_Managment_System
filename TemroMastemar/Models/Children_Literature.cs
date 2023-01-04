using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemroMastemar.Models
{
    public class Children_Literature
    {
        [Key]
        public int C_LiteratureID { get; set; }

        [Display(Name = "የፅሁፉ ርዕስ")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉ ርዕስ ያስገቡ")]
        public string C_LiteratureTitle { get; set; }

        [Display(Name = "የፅሁፉ ዓይነት")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉ ዓይነት ያስገቡ")]
        public string C_LiteratureType { get; set; } = "የለም";

        [Display(Name = "የፅሁፉ ይዘት")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉ ይዘት ያስገቡ")]
        public string C_LiteratureFor { get; set; }

        [Display(Name = "የተፃፈበት ወር")]
        public int? WrittenMonth { get; set; }

        [Display(Name = "የተፃፈበት ዓመተ ምህረት")]
        public int? WrittenYear { get; set; }

        [Display(Name = "የፀሓፊ ስም")]
        public string C_Author { get; set; }

        [Display(Name = "የዶሴዉ ስም")]
        public string C_Physical_Document { get; set; }

        [Display(Name = "ፅሁፉ")]
        public string? Document { get; set; }

        [NotMapped]
        [Display(Name = "ፅሁፉን ይጫኑ")]
        public IFormFile? LiteratureFile { get; set; }
    }
}
