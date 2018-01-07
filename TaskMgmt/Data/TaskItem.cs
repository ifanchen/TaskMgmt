using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMgmt.Data
{
    [Table("Task")]
    public class TaskItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public bool Status { get; set; }

        [MaxLength(100)]
        public string FileName { get; set; }

        [MaxLength(100)]
        public string FileContentType { get; set; }
    }
}
