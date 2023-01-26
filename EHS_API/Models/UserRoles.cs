using System.ComponentModel.DataAnnotations;

namespace EHS_API.Models
{
    public class UserRoles
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
