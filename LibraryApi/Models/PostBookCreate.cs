using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Models
{
    public class PostBookCreate : IValidatableObject
    {
        [Required(ErrorMessage ="Well we need a Title for sure!!")][MaxLength(200)]
        public string Title { get; set; }
        [Required][MaxLength(200)]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required][Range(1, int.MaxValue)]
        public int NumberOfPagese { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            // Way to reject specific book or title
            if (Title.ToLower() == "it" & Author.ToLower() == "king")  
            {
                yield return new ValidationResult("That book is not allowed",
                    new string[] { "Title", "Author" });
            }
            if (Genre.ToLower() == "non-fiction" && NumberOfPagese >500)
            {
                yield return new ValidationResult("Give me a break. You won't read that.",
                    new string[] { nameof(Genre), nameof(NumberOfPagese) });
            }
        }
    }
}
