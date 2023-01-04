using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TemroMastemar.ViewModel
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Display(Name = "ኃላፊነት")]
        [Required(ErrorMessage = "እባክዎ ኃላፊነት ያስገቡ")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new();
    }
}