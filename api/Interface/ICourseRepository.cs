namespace api;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync();

    Task<Course?> GetByIdAsync(long Id);
    Task<Course> AddAsync(Course courseModel);
    Task<Course?> UpdateAsync(long Id, UpdateCourseDto courseDto);
    Task<Course?> DeleteAsync(long Id);
    Task<bool> CourseExist(long Id);
}
