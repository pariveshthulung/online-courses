
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api;

public class LessonRepository : ILessonRepository
{
    private readonly ApplicationDbContext _context;
    public LessonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Lesson?> AddAsync(Lesson lesson)
    {
        // var lessonModel = lesson.ToLessonDto();
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();

        return lesson;
    }

    public async Task<Lesson?> DeleteAsync(long Id)
    {
        var lessonExist = await _context.Lessons.FirstOrDefaultAsync(x => x.ID == Id);

        if (lessonExist == null)
        {
            return null;
        }
        _context.Lessons.Remove(lessonExist);
        await _context.SaveChangesAsync();

        return lessonExist;
    }

    public async Task<List<Lesson>> GetAllAsync()
    {
        return await _context.Lessons.ToListAsync();
    }

    public async Task<Lesson?> GetByIdAsync(long Id)
    {
        return await _context.Lessons.FirstOrDefaultAsync(x => x.ID == Id);
    }

    public async Task<Lesson?> UpdateAsync(long Id, UpdateLessonDto lessonDto)
    {
        var lessonModel = await _context.Lessons.FirstOrDefaultAsync(x => x.ID == Id);

        if (lessonModel == null)
        {
            return null;
        }
        lessonModel.LessonTitle = lessonDto.LessonTitle;
        lessonModel.Description = lessonDto.Description;

        await _context.SaveChangesAsync();

        return lessonModel;
    }
}
