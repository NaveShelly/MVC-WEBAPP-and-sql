using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Networking312190796_318855038.Models
{
    public class Movies
    {
        [Key]
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name should contain at least 3 characthers")]
        public string Name { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Discription should contain at least 3 characthers")]
        public string Discription { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Category should contain at least 3 characthers")]
        public string Category { get; set; }
        [Required]
        public string date { get; set; }
        [Required]
        public string hour { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Please enter valid integer Number between 1-5")]
        public string HallNum { get; set; }
        //[Required]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "img should contain at least 3 characthers")]
        public string img { get; set; }
        [Required]
        public string age { get; set; }
        [Required]
        public string price { get; set; }
        [Required]
        [RegularExpression(@"(Sale|NotSale|Regular)", ErrorMessage = "Price status can be only Sale,NotSale,Regular")]
        public string priceStatus { get; set; }
        [Required]
        [RegularExpression(@"(Yes|No)", ErrorMessage = "Popularity  can be only Yes or No")]
        public string Popularity { get; set; }
    }
}