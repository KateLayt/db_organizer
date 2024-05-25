using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace organizer.Models
{
    public class TaskGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskGroupID { get; set; }

        [Required]
        public string? Name { get; set; }

        [StringLength(40)]
        public string? Description { get; set; }

        public bool IsBuiltin { get; set; }

        // Внешний ключ для связи с владельцем
        [ForeignKey("User")]
        public int? UserID { get; set; }

        public virtual User? User { get; set; }

        public virtual ICollection<Task>? Tasks { get; set; }

        public virtual ICollection<RepeatableTask>? RepeatableTasks { get; set; }

    }
}
