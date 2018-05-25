using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScrumWare.Models
{
    public class UserLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "entrer un email")]

        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "entrer un mot de passe ")]
        [DataType(DataType.Password)]
        public string MotPasse { get; set; }
    }
}