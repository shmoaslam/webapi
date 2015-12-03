using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BusinessEntities
{
    public partial class UserEntity
    {
        public long Id { get; set; }

        
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(50)]
        public string FName { get; set; }

        [StringLength(50)]
        public string LName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email cannot be left blank")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Address")]
        public string Email { get; set; }

        [StringLength(10, ErrorMessage = "Password should be between 6 to 10 charactors", MinimumLength = 6)]
        [Required(ErrorMessage = "Password cannot be left blank")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password cannot be left blank")]
        [Compare("Password", ErrorMessage = "Confirm password and password do no match")]
        public string ConfirmPassword { get; set; }
    }
}
