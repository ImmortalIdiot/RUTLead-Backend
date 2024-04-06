using api.Data;
using api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/RUTLead/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public StudentController(ApiDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _context.Students.ToListAsync();

            var studentDto = students.Select(s => s.ToStudentDto());

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.ToStudentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequestDto studentDto)
        {
            var studentModel = studentDto.ToStudentFromCreate();
            await _context.Students.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = studentModel.StudentId}, studentModel.ToStudentDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentRequestDto updateDto)
        {
            var studentModel = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);

            if (studentModel == null)
            {
                return NotFound();
            }

            studentModel.StudentId = updateDto.StudentId;
            studentModel.FullName = updateDto.FullName;
            studentModel.Email = updateDto.Email;
            studentModel.Group = updateDto.Group;
            studentModel.Password = updateDto.Password;

            await _context.SaveChangesAsync();

            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var studentModel = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);

            if (studentModel == null)
            {
                return NotFound();
            }
            
            _context.Students.Remove(studentModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
