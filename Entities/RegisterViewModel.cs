using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} area can not be empty."),
            StringLength(25, ErrorMessage = "{0} area should be max {1} character.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "{0} area can not be empty."),
            StringLength(70, ErrorMessage = "{0} area should be max {1} character."),
            EmailAddress(ErrorMessage = "Enter a valid email for {0} area")]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} area can not be empty."),
            DataType(DataType.Password),
            StringLength(25, ErrorMessage = "{0} area should be max {1} character.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "{0} area can not be empty."),
            DataType(DataType.Password),
            StringLength(25, ErrorMessage = "{0} area should be max {1} character."),
            Compare("Password", ErrorMessage = "{0} and {1} is not the same.")]
        public string RePassword { get; set; }
    }
}
