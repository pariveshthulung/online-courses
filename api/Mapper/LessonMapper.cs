namespace api;

public static class LessonMapper
{
    public static LessonDto ToLessonDto(this Lesson lessonModel)
    {
        return new LessonDto
        {
            ID = lessonModel.ID,
            LessonTitle = lessonModel.LessonTitle,
            Description = lessonModel.Description,
            CourseID = lessonModel.CourseID
        };
    }

    public static Lesson ToLessonFromAddDto(this AddLessonDto lessonDto, long Id)
    {
        return new Lesson
        {
            LessonTitle = lessonDto.LessonTitle,
            Description = lessonDto.Description,
            CourseID = Id
        };
    }
}
