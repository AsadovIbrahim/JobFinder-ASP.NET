using System.ComponentModel.DataAnnotations;

namespace JobFinderPractic.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
      
        public string Email { get; set; }

        public string Role { get; set; }
        [Required]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password),Compare(nameof(Password))]

        public string ConfirmPassword { get; set; }
    }
}
