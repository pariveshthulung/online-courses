namespace api;

public static class CourseMapper
{
    public static CoursesDTO coursesDTO(this Course course)
    {
        return new CoursesDTO
        {
            ID = course.ID,
            CourseTitle = course.CourseTitle,
            Description = course.Description,
            Lessons = course.Lessons.Select(x => x.ToLessonDto()).ToList()
        };
    }

    //insert into model
    public static Course toCourseFromAddDto(this AddCourseDto addCourseDto)
    {
        return new Course
        {
            CourseTitle = addCourseDto.CourseTitle,
            Description = addCourseDto.Description
        };
    }
}
