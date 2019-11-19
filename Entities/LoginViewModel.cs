using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} area can not be empty.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} area can not be empty."), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
