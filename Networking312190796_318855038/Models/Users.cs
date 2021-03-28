using System.ComponentModel.DataAnnotations;
namespace Networking312190796_318855038.Models
{
    public class Users
    {
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "First name should contain at least 3 characthers")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Last name should contain at least 3 characthers")]
        public string LastName { get; set; }
        [Key]
        [Required]
        [StringLength(40, MinimumLength = 9, ErrorMessage = "id contain 9 characthers")]
        public string ID { get; set; }
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Password must contain 9 digits")]
        public string password { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email must contain 9 digits")]
        public string email { get; set; }
        public string role { get; set; }
    }
}