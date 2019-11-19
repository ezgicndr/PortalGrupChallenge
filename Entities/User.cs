using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Surname { get; set; }

        [Required, StringLength(10)]
        public string Username { get; set; }

        [Required, MinLength(5), MaxLength(10)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}
