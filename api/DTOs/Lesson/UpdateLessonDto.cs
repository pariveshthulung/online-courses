namespace api;

public class UpdateLessonDto
{
    public string? LessonTitle { get; set; }
    public string? Description { get; set; }
    public long CourseID { get; set; }
}
