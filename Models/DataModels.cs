using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace mvccore.Models
{
    public class HeadingA
    {
        [Key]
        public int ID { get; set; }
        public int? Number { get; set; }
        public string? Heading { get; set; }
        public string? OldNew { get; set; }
    }

    public class HeadingB
    {
        [Key]
        public int Id { get; set; }
        public int? Number { get; set; }
        public string? Heading1 { get; set; }
        public string? Heading2 { get; set; }
        public string? OldNew { get; set; }
    }

    public class HeadingC
    {
        [Key]
        public int Id { get; set; }
        public int? Number { get; set; }
        public string? Heading1 { get; set; }
        public string? Heading2 { get; set; }
        public string? Heading3 { get; set; }
        public string? OldNew { get; set; }
    }



    public class Heading1
    {
        [Key]
        public int ID { get; set; }
        public string? Heading { get; set; }
        public string? OldNew { get; set; }
    }


    public class AudioLectures
    {
        public string? ID { get; set; }

        //[Required]
        public string? Class { get; set; }

        //[Required]
        public string? Topic { get; set; }

        [MaxLength(150, ErrorMessage ="Title cannot exceed 150 characters!")]
        public string? Title { get; set; }
        public string? Book { get; set; }
        public int? Chapter { get; set; }
        public int? Verse { get; set; }
        public DateTime? Date { get; set; }
        public string? Format { get; set; }
        public string? Presentation { get; set; }
        public string? Comment { get; set; }
        public string? Hyperlink { get; set; }
        public string? VideoLink { get; set; }
        public int? LogicalOrder { get; set; }
        
    }

    public class Commandments
    {
        public int? ID { get; set; }
        public int? Number { get; set; }
        public string? Text { get; set; }

    }

    public class BibleBooks
    {
        [Key]
        public int BookID { get; set; }
        public string? Book { get; set; }
        public string? Testament { get; set; }

    }

    public class JoinTable
    {
        [Key]
        public int Id { get; set; }
        public int? Code { get; set; }
        public string? BibRef { get; set; }
        public string? SubOutline { get; set; }
        public string? Year { get; set; }
        public string? Month{ get; set;}
        public string? Day { get; set; }
    }

    public class Bible
    {
        [Key]
        public int Id { get; set; }
        public string? BookRef { get; set; }
        public string? Text { get; set; }
        public string? Ord { get; set; }
    }

    public class Outline1
    {
        [Key]
        public int Id { get; set; }
        public string? BookName { get; set; }

    }

    public class Outline2
    {
        [Key]
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? Heading1 { get; set; }
    }

    public class Outline3
    {
        [Key]
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? Heading1 { get; set; }
        public string? Heading2 { get; set; }
    }

    public class Outline4
    {
        [Key]
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? Heading1 { get; set; }
        public string? Heading2 { get; set; }
        public string? Heading3 { get; set; }
    }


    public class Outline5
    {
        [Key]
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? Heading1 { get; set; }
        public string? Heading2 { get; set; }
        public string? Heading3 { get; set; }
        public string? Heading4 { get; set; }
    }

    public class Commentary
    {
        [Key]
        public int Id { get; set; }
        public string? Reference { get; set; }
        public string? Comment { get; set; }
    }

    public class Feedback
    {
        [Key]
        public int Id { get; set; }        
        public string? Email { get; set;}        
        public DateTime? Date { get; set;}
        public string? Comment { get; set; }
        public string? PublicComment { get; set;}
    }

    public class UserNames{
        [Key]
        public string? Email { get; set; }
        public string? First { get; set; }
        public string? Middle { get; set; }
        public string? Last { get; set; }
        public string? Company { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Password { get; set; }
    }

    public class Commands
    {
        [Key]
        public int Id { get; set; }
        public int? Number { get; set; }
        public string? Text { get; set; }
        public string? Roman { get; set; }
        public string? Day { get; set; }        
    }

    public class Journal
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Day { get; set; }
        public string? Entry { get; set; }
    }

    public class Gradebook
    {
        [Key]
        public int Id { get; set; }
        public string? UserEmail { get; set; }
        public string? UserID { get; set; }
        public string? CourseCode { get; set; }
        public string? Status { get; set; }
        public string? QuizScores { get; set; }
        public string? TestScores { get; set; }
        public string? PaperScores { get; set; }
        public string? FinalScore { get; set; }
        public string? FinalGrade { get; set; }
        public string? Progress { get; set; }
        public string? TeacherEmail { get; set; }
        public string? Password { get; set; }
    }

    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string? UserID { get; set; }
        public string? First { get; set; }
        public string? Middle { get; set; }
        public string? Last { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? StateProvince { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }

    public class LsnContext
    {
        public int Id { get; set; }
        public string? LessonId { get; set; }
        public string? LessonDesc { get; set; }
        public string? LessonComment { get; set; }
        public string? WebSite { get; set; }
        public string? Video { get; set; }
        public string? LessonTitle { get; set; }
        public string? WritingAssignment { get; set; }
    }

    public class Downloads
    {
        public int Id { get; set; }
        public string? Course { get; set; }
        public string? Unit { get; set; }
        public string? Lesson { get; set; }
        public string? Item { get; set; }
        public string? Desc { get; set; }
        public string? Link { get; set; }
    }

    public class QuizTable
    {
        public int Id { get; set; }
        public string? Course { get; set; }
        public string? QzRef { get; set; }
        public string? QzQst { get; set; }
        public string? QzAns { get; set; }
    }

    public class WritingAssignment
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? UserId { get; set; }
        public string? CourseCode { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? Critique { get; set; }
        public string? Score { get; set; }
        public string? AddCritique { get; set; }        
    }

    public class LessonGreek
    {
        public int Id { get; set; }
        public string? LessonId { get; set; }
        public string? LessonDesc { get; set; }
        public string? WebComment { get; set; }
        public string? WebSite { get; set; }
        public string? Video { get; set; }
        public string? LessonTitle { get; set; }
        public string? WritingAssignment { get; set; }
    }

    public class LessonDescription
    {
        public int Id { get; set; }
        public string? LsnId { get; set; }
        public string? LsnDesc { get; set; }
        public string? LsnTitle { get; set; }
        public string? Course { get; set; }
        public string? Video { get; set; }
        public string? WritingAssignment { get; set; }
        public string? Misc { get; set; }
    }

    public class texts
    {
        public int? Id { get; set; }
        public string? Text { get; set; }
    }

    public class GreekQuiz
    {
        public int? Id { get; set; }
        public string? IDX { get; set; }
        public string? QuizText { get; set; }
        public string? RightAnswer { get; set; }
        public string? Font { get; set; }
    }
}