using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;



namespace mvccore.Controllers
{
    public class IPNController : Controller
    {

        // private class IPNContext
        // {
        //     public HttpRequest IPNRequest { get; set; }
        //     public string RequestBody { get; set; }
        //     public string Verification { get; set; } = String.Empty;
        // }

        
        public IActionResult Listener(string first_name, string last_name, string payer_email, 
            string address_state, string address_country, string item_name, string item_name1, 
            string mc_gross)
        {

            //return RedirectToAction("index", "home");            
            
            string fromMail = "BruceGoreNoReply@gmail.com";
            string fromPassword = "iokpeurswtgnlelw";
            string strBody = "";
            string header = "";
            string course = "";
            string para0 = "";
            string para1 = "";
            string para2 = "";
            string para3 = "";

            switch(item_name)
            {
                case "NTGreek":
                    course = "New Testament Greek";
                    break;
                case "Context":
                    course = "Historical Context of the Bible";
                    break;
                 case "Philosophy1":
                    course = "Philosophy and History of Christian Thought (part 1)";
                    break;
                case "NTEasyGreek":
                    course = "Easy New Testament Greek";
                    break;
                default:
                    course = "Thank you!";
                    break;
            }
            
            
            para1 = "I sincerely hope you find this a very enjoyable and profitable program of study. " +
                "To get started, go to my website, www.brucegore.com and chose the 'Online Courses' tab. " +
                "Type your user name and password in the fields at the bottom of the page, and click 'submit.' " +
                "One or more icons will pop up representing the courses for which you are registered. " +
                "Click the icon and it will take you to the page for the course. " +
                "It should be self-explanatory from there.\n\n";

            para3 = "Again, I am very grateful that you have decided to enroll in " + course + ". " +
                "If you have any questions as you get started, please do not reply to this email. " + 
                "Instead, you may email me at bruce@brucegore.com. I am usually able to respond fairly quickly " +
                "to questions or comments.\n\n" + 
                "Thanks again, and blessing in your studies!\n\n" + 
                "Bruce";


            switch(item_name)
            {
                case "NTGreek":                    
                    para2 = "The most effective way to learn any language is to budget a little time " + 
                        "every day. Just 15 to 20 minutes should be sufficient to make steady progress. " +
                        "Each of the lessons in this course includes answers to the exercises in the Machen " +
                        "textbook, a video in which I cover the main topics of the lesson, and a self-correcting " +
                        "set of practice exercises you will do online. Once you have finished these, and taken " +
                        "the quiz that completes the lesson, you may move on to the next one. \n\n";
                    break;
                case "Context":                    
                    para2 = "Each lesson in this series is laid out in five steps. " + 
                        "After reading the brief introduction (step 1), you should read the " +
                        "collateral reading step 2). It may be helpful to listen to " +
                        "the lecture first (step 3), before reading the download. After listening to the  " +
                        "lecture and reading the download material, take the multiple question " +
                        "quiz (step 4), and then provide a short essay response to the final " +
                        "question (step 5). \n\n";                    
                    break;
                case "Philosophy1":                    
                    para2 = "Each lesson in this series is laid out in five steps. " + 
                        "After reading the brief introduction (step 1), you should read the " +
                        "collateral reading step 2). It may be helpful to listen to " +
                        "the lecture first (step 3), before reading the download. After listening to the  " +
                        "lecture and reading the download material, take the multiple question " +
                        "quiz (step 4), and then provide a short essay response to the final " +
                        "question (step 5). \n\n";
                    break;
                case "NTEasyGreek":                    
                    para1 = "You are fully registered, and may begin your first lesson by going " +
                        "to www.ReadNtGreek.com and when asked, entering the user name and " +
                        "password which you provided when you registered. If you have any questions as " +
                        "you get started, please do not reply to this email. " +
                        "Instead, you may email me at bruce@brucegore.com. I am usually able to respond fairly quickly " +
                        "to questions or comments.\n\n" +
                        "Blessings! \n\n" +
                        "Bruce";
                    para2 = "";
                    para3 = "";
                    break;
                default:
                    para0 = "*";
                    para1 = "Thank you for your support of our online ministry. We are very " +
                            "grateful for your interest and your willingness to participate in this way! " +
                            "We hope that you will, along with your financial assistance, also remember us " +
                            "in your prayers. If you would like to contact me, please do not reply to this " +
                            "email. Instead you can reach me at bruce@brucegore.com. " +
                            "We are grateful to have you as a partner in this project! \n\n" +
                            "Bruce";
                    para2 = "";
                    para3 = "";
                    break;
            }

            if(para0 != "*")
            {
                para0 = "Hi " + first_name + ", \n\n" + "Thanks for enrolling in this online course in " + course + "! ";
            }
            else
            {
                para0 = "Hi " + first_name + ", \n\n";
            }

            


            header = course + " (NO REPLY)";
            strBody = para0 + para1 + para2 + para3;

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = header;
            message.To.Add(new MailAddress(payer_email));
            message.Body = strBody;
            message.IsBodyHtml = false;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };
            smtpClient.Send(message);


            MailMessage mess2 = new MailMessage();
            mess2.From = new MailAddress(fromMail);
            mess2.Subject = header;
            mess2.To.Add(new MailAddress("bruce@brucegore.com"));            
            mess2.Body = strBody + "\n\n" + address_state + ", " + address_country;
            mess2.IsBodyHtml = false;

            var smtpClint = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };
            smtpClint.Send(mess2);


            return RedirectToAction("index", "home");
            
        }

        // private void VerifyTask(IPNContext ipnContext)
        // {
        //     try
        //     {
        //         var verificationRequest = WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");

        //         //Set values for the verification request
        //         verificationRequest.Method = "POST";
        //         verificationRequest.ContentType = "application/x-www-form-urlencoded";

        //         //Add cmd=_notify-validate to the payload
        //         string strRequest = "cmd=_notify-validate&" + ipnContext.RequestBody;
        //         verificationRequest.ContentLength = strRequest.Length;

        //         //Attach payload to the verification request
        //         using(StreamWriter writer = new StreamWriter(verificationRequest.GetRequestStream(),
        //         Encoding.ASCII))
        //         {
        //             writer.Write(strRequest);
        //         }
        //         //Send the request to PayPal and get the response
        //         using(StreamReader reader = new
        //         StreamReader(verificationRequest.GetResponse().GetResponseStream()))
        //         {
        //             ipnContext.Verification = reader.ReadToEnd();
        //         }
        //     }
        //     catch (Exception exception)
        //     {
        //         //Capture exception for manual investigation                
        //     }

        //     ProcessVerificationResponse(ipnContext);
        // }


        // private void LogRequest(IPNContext ipnContext)
        // {
        //     //Persist the request values into a database or temporary data store
        // }

        // private void ProcessVerificationResponse(IPNContext ipnContext)
        // {
        //     if (ipnContext.Verification.Equals("VERIFIED"))
        //     {
        //         // check that Payment_status=Completed
        //         // check that Txn_id has not been previously processed
        //         // check that Receiver_email is your Primary PayPal email
        //         // check that Payment_amount/Payment_currency are correct
        //         // process payment
        //     }
        //     else if (ipnContext.Verification.Equals("INVALID"))
        //     {
        //         //Log for manual investigation
        //     }
        //     else
        //     {
        //         // Log error
        //     }
        // }
    }
}

