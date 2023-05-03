using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication8.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ClassTypeId { get; set; }
        [ForeignKey("ClassTypeId")]
        public ClassType ClassType { get; set; }

    }
}
