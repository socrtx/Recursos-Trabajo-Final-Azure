using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorialMVC.Models
{
    public class Study
    {
        [Key]
        public int StudyID { get; set; }
        public string FirstName { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string GoogleMap { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

