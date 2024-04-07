using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;
[ApiController]
[Route("api/course")]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepo;
    public CourseController(ICourseRepository courseRepository)
    {

        _courseRepo = courseRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _courseRepo.GetAllAsync();
        var courseDto = courses.Select(x => x.coursesDTO());
        return Ok(courses);
    }
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var course = await _courseRepo.GetByIdAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);

    }

    [HttpPost]
    public async Task<IActionResult> AddCourse([FromBody] AddCourseDto CourseDto)
    {
        var courseModel = CourseDto.toCourseFromAddDto();

        await _courseRepo.AddAsync(courseModel);

        return CreatedAtAction("GetById", new { id = courseModel.ID }, courseModel);
    }

    [HttpPut("{id:long}")]

    public async Task<IActionResult> UpdateCource([FromRoute] long id, [FromBody] UpdateCourseDto updateCourseDto)
    {
        var courseModel = await _courseRepo.UpdateAsync(id, updateCourseDto);
        if (courseModel == null)
        {
            return NotFound();
        }

        //returning content based on filter of courseDto
        return Ok(courseModel.coursesDTO());
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteCourse([FromRoute] long id)
    {
        var courseModel = await _courseRepo.DeleteAsync(id);

        if (courseModel == null)
        {
            return NotFound();

        }

        return NoContent();
    }

}
