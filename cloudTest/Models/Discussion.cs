using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cloudTest.Models
{
    public class Discussion
    {
        public int ID { get; set; }
        [Required]
        public string Observer { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Coleague { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public string Outcome { get; set; }
        public string CreatedBy { get; set; }
    }
}