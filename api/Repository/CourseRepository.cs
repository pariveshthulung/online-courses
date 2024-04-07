
using Microsoft.EntityFrameworkCore;

namespace api;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;
    public CourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Course> AddAsync(Course courseModel)
    {
        await _context.Courses.AddAsync(courseModel);
        await _context.SaveChangesAsync();

        return courseModel;
    }

    public async Task<bool> CourseExist(long Id)
    {
        return await _context.Courses.AnyAsync(x => x.ID == Id);
    }

    public async Task<Course?> DeleteAsync(long Id)
    {
        var courseExist = await _context.Courses.FirstOrDefaultAsync(x => x.ID == Id);
        if (courseExist == null)
        {
            return null;
        }
        _context.Courses.Remove(courseExist);
        await _context.SaveChangesAsync();

        return courseExist;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await _context.Courses.Include(x => x.Lessons).ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(long Id)
    {
        return await _context.Courses.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.ID == Id);
    }

    public async Task<Course?> UpdateAsync(long Id, UpdateCourseDto courseDto)
    {
        var courseExist = await _context.Courses.FirstOrDefaultAsync(x => x.ID == Id);
        if (courseExist == null)
        {
            return null;
        }

        courseExist.CourseTitle = courseDto.CourseTitle;
        courseExist.Description = courseDto.Description;

        await _context.SaveChangesAsync();

        return courseExist;

    }
}
