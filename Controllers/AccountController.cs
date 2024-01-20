using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvccore.Models;
using mvccore.ViewModels;

namespace mvccore.Controllers
{    
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly AppDbContext _db;

        public AccountController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                AppDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");

        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var errorFlag = false;
            var rt = from ch in _db.UserNames where ch.Email == model.Email select ch;
            var ct = rt.Count();
            if (rt.Count() > 0)
            {                
                ViewBag.ErrorMessage = $"The email {model.Email} already exists!";
                return View("~/Views/Administration/NotFound.cshtml");
            }
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser 
                { 
                    UserName = model.Email, 
                    Email = model.Email,
                    City = model.City
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {

                    if(signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    errorFlag = true;
                }
                if(errorFlag)
                {
                    return View(model);        
                }
            }


            var comp = "F";
            if(model.Teacher)
            {
                comp = "T";
            }

            _db.UserNames.Add(new UserNames
            {
                Email = model.Email,
                First = model.FirstName,
                Middle = "",
                Last = model.LastName,
                Company = comp,
                Address1 = model.Address,
                Address2 = "",
                City = model.City,
                State = model.State,
                Country = model.Country,
                PostalCode = model.PostalCode,
                Password = model.Password
            });

            _db.SaveChanges();
            _db.Dispose();

            return View(model);
        }

        [HttpPost]
        //public async Task<IActionResult> stuRegister(launchCourseViewModel model)
        public IActionResult stuRegister(launchCourseViewModel model)
        {
            var pwd = "";
            var idz = 0;
            var useremail = "";
            var userid = "";
            var coursecode = "";
            var status = "";
            var quizscores = "";
            var testcores = "";
            var paperscores = "";
            var finalscore = "";
            var finalgrade = "";
            var progress = "";
            var teacheremail = "";
            var password = "";
            
            var rnt = from ch in _db.Gradebook
                    where ch.UserEmail == model.Email && ch.CourseCode == model.CourseCode                    
                    select ch;
            int ct = rnt.Count();

            switch(ct)
            {
                case 0:
                    string strFive = new string('0', 500);
                    string strOne = new string('0', 100);
                    string strTen = new string('0', 10);
                    var mx = _db.Gradebook.Max(e => e.Id) + 1;
                    useremail = model.Email;
                    coursecode = model.CourseCode;
                    status = "S";
                    quizscores = strFive;
                    testcores = strFive;
                    paperscores = strOne;
                    finalscore = strTen;
                    finalgrade = "I";
                    progress = "1011";
                    teacheremail = model.TeacherEmail;
                    password = model.Password;

                    _db.Gradebook.Add(new Gradebook
                    {
                        Id = mx,
                        UserEmail = useremail,
                        UserID = userid,
                        CourseCode = coursecode,
                        Status = status,
                        QuizScores = quizscores,
                        TestScores = testcores,
                        PaperScores = paperscores,
                        FinalScore = finalscore,
                        FinalGrade = finalgrade,
                        Progress = progress,
                        TeacherEmail = teacheremail,
                        Password = password
                    });
                    _db.SaveChanges();
                    _db.Dispose();
                    ViewBag.status = "2";
                    //this is the routine for a new gradebook entry
                    break;
                case 1:
                    //this is for pre-existing entry, check password
                    var ida = from ch in _db.Gradebook 
                        where ch.UserEmail == model.Email && ch.CourseCode == model.CourseCode 
                        let pw = ch.Password select pw;
                        foreach (var n in ida) { pwd = n; }
                        
                    if(pwd != model.Password)
                    {
                        ViewBag.status = "1";
                    }
                    else
                    {
                        var idx = from ch in _db.Gradebook 
                            where ch.UserEmail == model.Email && ch.CourseCode == model.CourseCode 
                            let idy = ch.Id select idy;
                            foreach (var m in idx) { idz = m; }
                    }
                    var r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.UserEmail select i1;
                    foreach( var m in r1) { useremail = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.UserID select i1;
                    foreach( var m in r1) { userid = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.CourseCode select i1;
                    foreach( var m in r1) { coursecode = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.Status select i1;
                    foreach( var m in r1) { status = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.QuizScores select i1;
                    foreach( var m in r1) { quizscores = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.TestScores select i1;
                    foreach( var m in r1) { testcores = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.PaperScores select i1;
                    foreach( var m in r1) { paperscores = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.FinalScore select i1;
                    foreach( var m in r1) { finalscore = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.FinalGrade select i1;
                    foreach( var m in r1) { finalgrade = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.Progress select i1;
                    foreach( var m in r1) { progress = m; }

                    //this field is being update in this routine
                    // r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.TeacherEmail select i1;
                    // foreach( var m in r1) { teacheremail = m; }

                    r1 = from ch in _db.Gradebook where ch.Id == idz let i1 = ch.Password select i1;
                    foreach( var m in r1) { password = m; }

                    _db.Gradebook.Update(new Gradebook
                    {
                        Id = idz,
                        UserEmail = useremail,
                        UserID = userid,
                        CourseCode = coursecode,
                        Status = status,
                        QuizScores = quizscores,
                        TestScores = testcores,
                        PaperScores = paperscores,
                        FinalScore = finalscore,
                        FinalGrade = finalgrade,
                        Progress = progress,
                        TeacherEmail = model.TeacherEmail,
                        Password = password
                    });
                    _db.SaveChanges();
                    _db.Dispose();
                    ViewBag.status = "2";
                    break;
                default:
                    //this should not happen, multiple gradebook entries - send error message
                    break;
            }

            ViewBag.course = model.CourseCode;
            ViewBag.user = model.TeacherEmail;
            return View("~/Views/Home/launchCourse.cshtml");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {

            var user = model.Email;
            //ViewBag.chk = user;
            ViewData["chk"] = "here";


            if (returnUrl != null)
            {
                returnUrl = returnUrl.Replace("%2F", "/");
                returnUrl = "~" + returnUrl;
            }

            if(ModelState.IsValid)
            {                
                var result = await signInManager.PasswordSignInAsync(model.Email, 
                                model.Password, model.RememberMe, false);

                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }                    
                }
                
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");                
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}