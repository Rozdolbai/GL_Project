using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLib.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public virtual IdentityUser User { get; set; }
    }
}
