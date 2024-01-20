using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvccore.Models;

namespace mvccore.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee? Employee { get; set; }
        public string? PageTitle { get; set; }

    }
}
