namespace api;

public class LessonDto
{
    public long ID { get; set; }
    public string? LessonTitle { get; set; }
    public string? Description { get; set; }
    public long CourseID { get; set; }
}
