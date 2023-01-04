using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemroMastemar.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; } 
        [Display(Name = "ፎቶ")]
        public string? Image { get; set; }
        [Required(ErrorMessage = "እባክዎ ስም ያስገቡ")]
        [Display(Name = "ሙሉ ስም እስከ አባት")]
        public string FullName { get; set; }

        [Display(Name = "የአያት ስም")]
        public string? GrandFather_Name { get; set; }

        [Display(Name = "የእናት ስም")]
        public string? Mother_Name { get; set; }

        [Display(Name = "ፆታ")]
        [Required(ErrorMessage = "እባክዎ ፆታ ያስገቡ")]
        public string Gender { get; set; }

        [Display(Name = "ዜግነት")]
        [Required(ErrorMessage = "እባክዎ ዜግነት ያስገቡ")]
        public string Nationality { get; set; } = "ኢትዮጵያዊ";

        [Display(Name = "የክርስትና ስም")]
        public string? Babtisal_Name { get; set; }

        [Display(Name = "የትውልድ ቀን")]
        public int? DateofBirth { get; set; }

        [Display(Name = "የትውልድ ወር")]
        public string? MonthofBirth { get; set; }

        [Display(Name = "የትውልድ ዓመተ ምህረት")]
        public int? YearofBirth { get; set; }

        [Display(Name = "የትውልድ ቦታ")]
        public string? PlaceofBirth { get; set; }

        [Display(Name = "የጋብቻ ሁኔታ")]
        public string? Marital_Status { get; set; }

        [Display(Name = "ክፍለ ከተማ")]
        public string? Sub_City { get; set; }

        [Display(Name = "ወረዳ")]
        public int? Woreda { get; set; }

        [Display(Name = "የቤት ቁጥር")]
        public int? House_Number { get; set; }

        [Display(Name = "ስልክ ቁጥር")]
        public string? Phone_Number { get; set; }

        [Display(Name = "የትምህርት ደረጃ")]
        public string? Education_Status { get; set; }

        [Display(Name = "የተማሩበት መስክ")]
        public string? Education_Field { get; set; }

        [Display(Name = "የሥራ መስክ")]
        public string? WorkingIn { get; set; }

        [Display(Name = "የሥራ ወይም የትምህርት ቦታ")]
        public string? Organization_Name { get; set; }

        [Display(Name = "አሁን ያሉበት ኮሚቴ")]
        public string? Current_Committee { get; set; }

        [Display(Name = "የኮሚቴ ምርጫዎ")]
        public string? Committe_Choice { get; set; }

        [Display(Name = "የአባልነት ዓመተ ምህረት")]
        public string? YearofMembership { get; set; }

        [Display(Name = "የአደጋ ጊዜ ተጠሪ")]
        public string? EmergencyContactName { get; set; }

        [Display(Name = "ከተጠሪው ጋር ያለው ዝምድና")]
        public string? EC_Relation { get; set; }

        [Display(Name = "የተጠሪው ክፍለ ከተማ")]
        public string? EC_Sub_City { get; set; }

        [Display(Name = "የተጠሪው ወረዳ")]
        public int? EC_Woreda { get; set; }

        [Display(Name = "የተጠሪው የቤት ቁጥር")]
        public int? EC_House_Number { get; set; }

        [Display(Name = "የተጠሪው ስልክ ቁጥር")]
        public string? EC_Phone_Number { get; set; }

        [Display(Name = "በህይወት አሉ")]
        public string? IsAlive { get; set; }

        [NotMapped]
        [Display(Name = "ፎቶ ይጫኑ")]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? NameAndGrFName
        {
            get
            {
                return this.FullName + " " + this.GrandFather_Name;
            }
        }
    }
}
//Made by Endeamlak. Z
