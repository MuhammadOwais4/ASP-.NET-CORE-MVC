using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_11.Models
{
    public class StudentViewModel
    {
        [Key]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Subject { get; set; }
    }
}
