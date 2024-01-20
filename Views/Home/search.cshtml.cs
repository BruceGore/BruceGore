using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using mvccore.Models;




namespace mvccore
{
    public class SearchModel : PageModel
    {
        //private readonly AppDbContext _adb;


        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Hello World!";

        }
        //public SearchModel(AppDbContext adb)
        //{
        //    _adb = adb;
        //}

    }
}
