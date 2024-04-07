namespace api;

public interface ILessonRepository
{
    Task<List<Lesson>> GetAllAsync();
    Task<Lesson?> GetByIdAsync(long Id);
    Task<Lesson?> AddAsync(Lesson lesson);
    Task<Lesson?> UpdateAsync(long Id, UpdateLessonDto lessonDto);
    Task<Lesson?> DeleteAsync(long Id);
}
