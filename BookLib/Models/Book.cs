using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookLib.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Book description is required")]
        public string Description { get; set; }
        public string Author { get; set; }
        public string DownloadRef { get; set; }
        public string PictureRef { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
