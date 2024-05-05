using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer.Models
{
    public class RepeatableTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepeatableTaskID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Interval;

        public DateTime? LastDone { get; set; }

        public DateTime? Deadline { get; set; }

        public string? Status { get; set; }

        [ForeignKey("TaskGroup")]
        public int? TaskGroupID { get; set; }

        public virtual TaskGroup? TaskGroup { get; set; }
    }
}
