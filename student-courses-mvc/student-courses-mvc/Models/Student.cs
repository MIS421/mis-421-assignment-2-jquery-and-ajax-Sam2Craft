using System.ComponentModel.DataAnnotations;

namespace student_courses_mvc.Models
{
    public class Student
    {
        [Key] // Tells model that when it links up with DB that the thing below is meant to be the PK for the table, not necessary if u just call it Id
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Major { get; set; }
        private DateTime DOB { get; set; }
    }
}