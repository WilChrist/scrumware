using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScrumWare.Models
{
    [MetadataType(typeof(MetaDataUser))]
    public partial class User
    {
       
    }
    public class MetaDataUser
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ntrer un First Name")]

        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "entrer un Last Name")]

        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "entrer un mot de passe")]
        [DataType(DataType.Password)]
        public string MotPasse { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "entrer un description")]

        public string Description { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "entrer un email")]

        public string Email { get; set; }
       
         
    
    }
}