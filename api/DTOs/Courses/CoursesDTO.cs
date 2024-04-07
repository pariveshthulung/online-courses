namespace api;

public class CoursesDTO
{
    public long ID { get; set; }
    public string? CourseTitle { get; set; }
    public string? Description { get; set; }
    public List<LessonDto>? Lessons { get; set; }
}
