using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ketomaner_Website.ViewModels
{
    public class RegisterUserVm
    {
        public string Username { get; set; }

        public string Test { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage = "The passwords dont match")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}
