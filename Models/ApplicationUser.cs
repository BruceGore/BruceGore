using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace mvccore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}