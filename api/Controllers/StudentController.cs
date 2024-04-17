using api.Data;
using api.Dto;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/RUTLead/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApiDBContext _context;
        private readonly IStudentRepository _studentRepo;

        public StudentController(ApiDBContext context, IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepo.GetAllAsync();

            var studentDto = students.Select(s => s.ToStudentDto());

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);

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
            await _studentRepo.CreateAsync(studentModel);
            return CreatedAtAction(nameof(GetById), new {id = studentModel.StudentId}, studentModel.ToStudentDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentRequestDto updateDto)
        {
            var studentModel = await _studentRepo.UpdateAsync(id, updateDto);

            if (studentModel == null)
            {
                return NotFound();
            }

            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var studentModel = await _studentRepo.DeleteAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
