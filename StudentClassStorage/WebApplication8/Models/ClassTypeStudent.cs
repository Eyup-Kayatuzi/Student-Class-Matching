using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication8.Models
{
    public class ClassTypeStudent
    {
        public Student Student { get; set; }
        public ClassType ClassType { get; set; }

        public List<Student> Students { get; set; }
        public List<ClassType> ClassTypes { get; set; }
        public List<SelectListItem> StudentClassType { get; set; } = new List<SelectListItem>();
        public int TargetValue { get; set; }
    }
}
