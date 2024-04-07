using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class Lesson
{
    public long ID { get; set; }
    public string? LessonTitle { get; set; }
    public string? Description { get; set; }
    public long CourseID { get; set; }
    [ForeignKey("CourseID")]
    public virtual Course? Course { get; set; }
}
