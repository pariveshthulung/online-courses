using Microsoft.AspNetCore.Mvc;

namespace api;
[ApiController]
[Route("api/course/lesson")]
public class LessonController : ControllerBase
{
    private readonly ILessonRepository _lessonRepo;
    private readonly ICourseRepository _courserepo;
    public LessonController(ILessonRepository lessonRepository, ICourseRepository courseRepository)
    {
        _lessonRepo = lessonRepository;
        _courserepo = courseRepository;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var lessons = await _lessonRepo.GetAllAsync();
        var lessonDto = lessons.Select(x => x.ToLessonDto());

        return Ok(lessonDto);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var lesson = await _lessonRepo.GetByIdAsync(id);
        if (lesson == null)
        {
            return NotFound();
        }
        return Ok(lesson.ToLessonDto());
    }

    [HttpPost("{id:long}")]
    public async Task<IActionResult> AddLesson([FromRoute] long id, [FromBody] AddLessonDto lessonDto)
    {
        if (!await _courserepo.CourseExist(id))
        {
            return BadRequest("Course doesnot exist");
        }
        var lessonModel = lessonDto.ToLessonFromAddDto(id);

        await _lessonRepo.AddAsync(lessonModel);
        // return CreatedAtAction(nameof(GetById), new { id = lessonModel.ID }, lessonModel);
        return Ok(lessonModel);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateLesson([FromRoute] long id, [FromBody] UpdateLessonDto lessonDto)
    {
        var lessonModel = await _lessonRepo.UpdateAsync(id, lessonDto);
        if (lessonModel == null)
        {
            return NotFound();
        }

        return Ok(lessonModel.ToLessonDto());
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteLesson([FromRoute] long id)
    {
        var lesson = await _lessonRepo.DeleteAsync(id);
        if (lesson == null)
        {
            return NotFound();
        }
        return NoContent();
    }

}
