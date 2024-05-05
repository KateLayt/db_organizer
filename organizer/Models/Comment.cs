using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        [Required]
        [StringLength(40)]
        public string? CommentText { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }

        public virtual User? User { get; set; }


    }
}
