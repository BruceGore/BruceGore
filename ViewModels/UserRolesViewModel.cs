using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvccore.ViewModels
{
    public class UserRolesViewModel
    {
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public bool IsSelected { get; set; }
        public string? UserId { get; set; }
    }
}