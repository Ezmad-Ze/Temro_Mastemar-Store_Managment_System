using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TemroMastemar.Models
{
    public class DefaultUser:IdentityUser
    {
        [PersonalData]
        public string? FullName { get; set; }
        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime UserCreationDate { get; set; } = DateTime.Now;
    }
}
