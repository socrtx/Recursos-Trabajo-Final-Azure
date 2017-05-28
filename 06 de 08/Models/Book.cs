using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorialMVC.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Subject { get; set; }
        public string Price { get; set; }
        public string Frontpage { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

