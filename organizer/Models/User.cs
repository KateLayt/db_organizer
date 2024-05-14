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

        public static void SetBaseUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserID = -3, Name = "Дашуля", Username = "dasha", HashPassword = "dasha", IsMale = false },
                new User { UserID = -2, Name = "Катюша", Username = "katya", HashPassword = "katya", IsMale = false },
                new User { UserID = -1, Name = "Пользователь", Username = "user", HashPassword = "user", IsMale = true }
            );
        }

    }
}
