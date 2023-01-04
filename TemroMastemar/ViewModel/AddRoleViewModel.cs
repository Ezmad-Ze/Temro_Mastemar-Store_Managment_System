using System.ComponentModel.DataAnnotations;

namespace TemroMastemar.ViewModel
{
    public class AddRoleViewModel
    {
        [Required(ErrorMessage = "እባክዎ ኃላፊነት ያስገቡ")]
        [Display(Name = "ኃላፊነት")]
        public string RoleName { get; set; }
    }
}
//Made by Endeamlak. Z