using System.ComponentModel.DataAnnotations;

namespace InfoPortal.Common.Models
{
    public class Language : ITable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The string length must be between 3 and 50 characters")]
        public string Name { get; set; }
    }
}
