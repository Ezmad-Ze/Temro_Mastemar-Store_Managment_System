using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemroMastemar.Models
{
    public class Rule
    {
        [Key]
        public int RuleID { get; set; }

        [Display(Name = "የመመሪያው ርዕስ")]
        [Required(ErrorMessage = "እባክዎ የመመሪያው ርዕስ ያስገቡ")]
        public string RuleTitle { get; set; }

        [Display(Name = "ቀን")]
        public int? RuleDate { get; set; }

        [Display(Name = "ወር")]
        public int? RuleMonth { get; set; }

        [Display(Name = "ዓመተ ምህረት")]
        public int? RuleYear { get; set; }

        [Display(Name = "የመመሪያው አውጪ")]
        [Required(ErrorMessage = "እባክዎ የመመሪያው አውጪ ያስገቡ")]
        public string RuleBy { get; set; }

        [Display(Name = "የዶሴዉ ስም")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉን ዶሴ ስም ያስገቡ")]
        public string Physical_Document { get; set; }

        [Display(Name = "ፅሁፉ")]
        public string? Document { get; set; }

        [NotMapped]
        [Display(Name = "ፅሁፉን ይጫኑ")]
        public IFormFile? RuleFile { get; set; }
    }
}
