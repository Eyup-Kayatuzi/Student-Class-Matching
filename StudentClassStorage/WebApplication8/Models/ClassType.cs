namespace WebApplication8.Models
{
    public class ClassType
    {
        public int Id { get; set; }

        public int Level { get; set; }
        public string Branch { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
