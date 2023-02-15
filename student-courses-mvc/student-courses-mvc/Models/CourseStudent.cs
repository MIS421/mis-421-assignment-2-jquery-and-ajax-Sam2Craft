using System.ComponentModel.DataAnnotations.Schema; // necessary for fk

namespace student_courses_mvc.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }

        [ForeignKey("Student")] // foreign key asumes first attribute listed to be the fk
        public int? StudentId { get; set; }

        public Student? Student { get; set; } // other student data stored in this line (name, dob, etc)

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public Course? Course { get; set; }
    }
}