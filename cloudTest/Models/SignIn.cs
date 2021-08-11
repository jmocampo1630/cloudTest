using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cloudTest.Models
{
    public class SignInDto
    {
        [Required]
        public string User { get; set; }
    }
}