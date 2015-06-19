using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BullsAndCows.Web.Models
{
    public class Guess
    {
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Your guess should be exactly 4 characters long.")]
        [RegularExpression(@"[1-9]*\.?[1-9]+", ErrorMessage = "Your guess must have the numbers 1 to 9 only.")]
        public string Input { get; set; }
    }
}