using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemroMastemar.Models
{
    public class Meeting
    {
        [Key]
        public int MeetingID { get; set; }

        [Display(Name = "የስብሰባው አጀንዳ")]
        [Required(ErrorMessage = "እባክዎ የስብሰባው አጀንዳ ያስገቡ")]
        public string MeetingAgenda { get; set; }

        [Display(Name = "የሰብሳቢ ስም")]
        [Required(ErrorMessage = "እባክዎ የሰብሳቢ ስም ያስገቡ")]
        public int MemberID { get; set; }
        public virtual Member? member { get; set; }

        [Display(Name = "የስብሰባው ቦታ")]
        public string? MeetingPlace { get; set; }

        [Display(Name = "የስብሰባው ሰዓት")]
        public string? MeetingHour { get; set; }

        [Display(Name = "የተፃፈበት ቀን")]
        public int? MeetingDate { get; set; } = 1;

        [Display(Name = "የተፃፈበት ወር")]
        [Required(ErrorMessage = "እባክዎ የተፃፈበት ወር ያስገቡ")]
        public int MeetingMonth { get; set; } = 10;

        [Display(Name = "የተፃፈበት ዓ.ም")]
        [Required(ErrorMessage = "እባክዎ የተፃፈበት ዓመተ ምህረት ያስገቡ")]
        public int MeetingYear { get; set; } = 2009;

        [Display(Name = "የዶሴዉ ስም")]
        [Required(ErrorMessage = "እባክዎ የዶሴዉ ስም ያስገቡ")]
        public string Physical_Document { get; set; }

        [Display(Name = "ፅሁፉ")]
        public string? Document { get; set; }

        [NotMapped]
        [Display(Name = "ፅሁፉን ይጫኑ")]
        public IFormFile? MeetingFile { get; set; }
    }
}
