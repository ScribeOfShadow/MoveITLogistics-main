using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDbCRUD.Models.Domain
{
    public class UserAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Please Enter Your Password.")]
        [DataType(DataType.Password)]
        //[Required(ErrorMessage = "Confirm Pasword is required")]
        public string? ConfirmPassword { get; set; }

        
        [ForeignKey("Role")]
        public int? RoleName { get; set; }
        public RoleType? Role { get; set; }

    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}