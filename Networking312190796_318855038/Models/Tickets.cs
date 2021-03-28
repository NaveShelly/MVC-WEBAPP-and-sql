using System.ComponentModel.DataAnnotations;

namespace Networking312190796_318855038.Models
{
    public class Tickets
    {
        public static int number=0;
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name should contain at least 3 characthers")]
        public string Name { get; set; }
        [Key]
        [Required]
        public string ticketnum { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Please enter valid integer Number between 1-10")]
        public string row { get; set; }
        [Required]
        [Range(0, 20, ErrorMessage = "Please enter valid integer Number between 1-10")]
        public string seat { get; set; }
        [Required]
        public string date { get; set; }
        [Required]
        public string hour { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Please enter valid integer Number between 1-5")]
        public string HallNum { get; set; }
    }
}