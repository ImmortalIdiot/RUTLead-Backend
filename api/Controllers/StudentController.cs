using api.Data;
using api.Dto;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var students = _context.Students.ToList()
            .Select(s => s.ToStudentDto());

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.ToStudentDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentRequestDto studentDto)
        {
            var studentModel = studentDto.ToStudentFromCreate();
            _context.Students.Add(studentModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = studentModel.StudentId}, studentModel.ToStudentDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStudentRequestDto updateDto)
        {
            var studentModel = _context.Students.FirstOrDefault(s => s.StudentId == id);

            if (studentModel == null)
            {
                return NotFound();
            }

            studentModel.StudentId = updateDto.StudentId;
            studentModel.FullName = updateDto.FullName;
            studentModel.Email = updateDto.Email;
            studentModel.Group = updateDto.Group;
            studentModel.Password = updateDto.Password;

            _context.SaveChanges();

            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var studentModel = _context.Students.FirstOrDefault(s => s.StudentId == id);

            if (studentModel == null)
            {
                return NotFound();
            }
            
            _context.Students.Remove(studentModel);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
