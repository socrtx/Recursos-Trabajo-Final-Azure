using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorialMVC.Models
{
    public class Director
    {
        [Key]
        public int DirectorID { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Biography { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}