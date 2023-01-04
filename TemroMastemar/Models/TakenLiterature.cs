using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemroMastemar.Models
{
    public class TakenLiterature
    {
        [Key]
        public int TakenLiteratureID { get; set; }

        [Display(Name = "የሚወጣበት ምክንያት")]
        [Required(ErrorMessage = "እባክዎ ምክንያት ያስገቡ")]
        public string TL_Reason { get; set; }

        [Display(Name = "የፅሁፉ ርዕስ")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉ ርዕስ ያስገቡ")]
        public string TL_Title { get; set; }

        [Display(Name = "የፅሁፉ ዓይነት")]
        [Required(ErrorMessage = "እባክዎ የፅሁፉ ዓይነት ያስገቡ")]
        public string TL_LiteratureType { get; set; } = "የለም";

        [Display(Name = "የአውጪው ስም")]
        [Required(ErrorMessage = "እባክዎ የአውጪውን ስም ያስገቡ")]
        public string Giver { get; set; }

        [Display(Name = "የወሳጅ ስም")]
        [Required(ErrorMessage = "እባክዎ የወሳጅን ስም ያስገቡ")]
        public string Taker { get; set; }

        [BindNever]
        public DateTime? TL_Time { get; set; } = DateTime.Now;

    }
}
