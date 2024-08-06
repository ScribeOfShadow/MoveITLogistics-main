using System.ComponentModel.DataAnnotations;
namespace TestDbCRUD.Models.Domain
{
    public class UserAccountAdd
    {

        [Required(ErrorMessage = "First Name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Plaease Enter Your Password.")]
        [DataType(DataType.Password)]
        //[Required(ErrorMessage = "Confirm Pasword is required")]
        public string? ConfirmPassword { get; set; }
        public string? RoleName { get; set; }
    }
}