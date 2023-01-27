using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHS_API.Models
{
    [Index(nameof(Email),IsUnique =true)]
    [Index(nameof(UserName),IsUnique =true)]
    public class UserDetails
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the User Name")]
        [MaxLength(50)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User name should be minimum of 3 characters and maximum of 50 characters")]
        public string UserName { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        [Required(ErrorMessage ="Please enter the Email Address")]
        [EmailAddress(ErrorMessage = "please enter a valid email address")]
        public string Email { get; set; }

        //Reference
        public Seller seller { get; set; }
        public int SellerId { get; set; }

        public UserRoles Roles { get; set; }

        public int RolesId { get; set; }

    }

    public class LoginDto
    {


        [Required(ErrorMessage = "Please enter the User Name")]
        [MaxLength(50)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User name should be minimum of 3 characters and maximum of 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password is too short.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password does not match.")]
        public string ConfirmPassword { get; set; }


    }
}
