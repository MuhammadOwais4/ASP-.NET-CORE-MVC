using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_11.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Column]
        [Required(ErrorMessage = "Please Add Name Ok")]
        [StringLength(20 , MinimumLength = 3)]
        public string Name { get; set; }

        //[Required]
        //[EmailAddress]
        //public string email { get; set; }

        [Column]
        [Required]
        [Range(50000, 100000)]
        public int Salary { get; set; }

        [Column]
        [Required]
        [MinLength(5)]
        [MaxLength(18)]
        public string Designation{ get; set; }

        [Column]
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
