using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace mvccore.ViewModels
{
    public class launchCourseViewModel
    {

        [Required]
        [EmailAddress]
        // [Remote(action: "IsEmailInUse", controller:"Account")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Id { get; set; }

        public string? UserId { get; set; }

        public string? CourseCode { get; set; }

        public string? Question { get; set; }

        public string? Answer { get; set; }

        public string? Critique { get; set; }

        public string? Score { get; set; }

        public string? AddCritique { get; set; }

        public string? TeacherEmail { get; set; }

        public string? SaveTitle { get; set; }

    }

}