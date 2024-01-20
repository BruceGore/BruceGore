using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

namespace mvccore.Models{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
        {
            
        }

        public DbSet<AudioLectures>? AudioLectures { get; set; }
        public DbSet<Heading1>? Heading1 { get; set;}
        public DbSet<Commandments>? Commandments { get; set; }
        public DbSet<BibleBooks>? BibleBooks { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<HeadingA>? HeadingA { get; set; }
        public DbSet<HeadingB>? HeadingB { get; set;}
        public DbSet<HeadingC>? HeadingC { get; set;}
        public DbSet<JoinTable>? JoinTable { get; set; }
        public DbSet<Bible>? Bible { get; set;}
        public DbSet<Outline1>? Outline1 { get; set; }        
        public DbSet<Outline2>? Outline2 { get; set; }
        public DbSet<Outline3>? Outline3 { get; set; }
        public DbSet<Outline4>? Outline4 { get; set; }
        public DbSet<Outline5>? Outline5 { get; set; }
        public DbSet<Commentary>? Commentary { get; set;}
        public DbSet<Feedback>? Feedback { get; set;}
        public DbSet<UserNames>? UserNames { get; set;}
        public DbSet<Commands>? Commands { get; set;}
        public DbSet<Journal>? Journal { get; set; }
        public DbSet<Gradebook>? Gradebook { get; set; }
        public DbSet<Students>? Students { get; set; }
        public DbSet<LsnContext>? LsnContext { get; set; }
        public DbSet<Downloads>? Downloads { get; set; }
        public DbSet<QuizTable>? QuizTable { get; set; }
        public DbSet<WritingAssignment>? WritingAssignment { get; set; }
        public DbSet<LessonGreek>? LessonGreek { get; set; }
        public DbSet<LessonDescription>? LessonDescription { get; set; }
        public DbSet<texts>? texts { get; set; }
        public DbSet<GreekQuiz>? GreekQuiz { get; set; }
        
    }
}