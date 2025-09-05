using System.ComponentModel.DataAnnotations;

namespace LanoiraM_6th.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        public string FullName {  get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, Range(1, 100)]
        public int Age { get; set; }
    }
}
