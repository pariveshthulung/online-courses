namespace api;

public class Course
{
    public long ID { get; set; }
    public string? CourseTitle { get; set; }
    public string? Description { get; set; }
    public virtual List<Lesson>? Lessons { get; set; }
}
