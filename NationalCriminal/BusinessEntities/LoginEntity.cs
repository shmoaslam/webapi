using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class LoginEntity
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Email cannot be left blank")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Address")]
        public string Email { get; set; }

        [StringLength(10, ErrorMessage = "Password should be between 6 to 10 charactors", MinimumLength = 6)]
        [Required(ErrorMessage = "Password cannot be left blank")]
        public string Password { get; set; }
    }
}
