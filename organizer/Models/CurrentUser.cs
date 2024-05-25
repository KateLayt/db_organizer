using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using organizer.Models;

namespace organizer.Models 
{
    public class CurrentUser
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    } 
}


