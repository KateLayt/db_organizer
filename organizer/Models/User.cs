using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;

namespace organizer.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Username { get; set; }

        [Required]
        public string? HashPassword { get; set; }

        [Required]
        public bool? IsMale { get; set; }

        public int? AvatarID { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<TaskGroup>? TaskGroups { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

    }
}
