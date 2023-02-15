using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using student_courses_mvc.Models;

namespace student_courses_mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<student_courses_mvc.Models.Student> Student { get; set; } // tells DB wwe want to store students, must have

        public DbSet<student_courses_mvc.Models.Course> Course { get; set; }

        public DbSet<student_courses_mvc.Models.CourseStudent> CourseStudent { get; set; }
    }// use pacage manager console to commit this new entity to the DB "add-migration" then "update-database"
}