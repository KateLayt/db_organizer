using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace organizer.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        [Required]
        public string? Name { get; set; }

        public DateTime? Deadline { get; set; }

        public string? Status { get; set; }

        [ForeignKey("TaskGroup")]
        public int? TaskGroupID { get; set; }

        [JsonIgnore]
        public virtual TaskGroup? TaskGroup { get; set; }

    }
}
