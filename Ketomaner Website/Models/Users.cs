using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ketomaner_Website.Models
{
    public class Users : IdentityUser
    {
        public string TEST { get; set; }
    }
}
