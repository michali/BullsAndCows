using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BullsAndCows.Web.Models
{
    public class Guess
    {
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "The guess should be exactly 4 characters long.")]
        public string Input { get; set; }
    }
}