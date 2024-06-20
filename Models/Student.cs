namespace UniversityMarks.Models
{
    public class Strudent    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
