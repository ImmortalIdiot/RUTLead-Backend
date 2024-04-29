using api.Data;
using api.Dto;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApiDBContext _context;
        private readonly IPasswordHasher<Student> _passwordHasher;
        public StudentRepository(ApiDBContext context, IPasswordHasher<Student> passwordHasher) 
            {
                _passwordHasher = passwordHasher;
                _context = context;
            }

        public async Task<Student?> CreateAsync(Student studentModel)
        {
            await _context.Students.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            return studentModel;
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            var studentModel = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);

            if (studentModel == null)
            {
                return null;
            }

            _context.Students.Remove(studentModel);
            await _context.SaveChangesAsync();

            return studentModel;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student?> UpdateAsync(int id, UpdateStudentRequestDto updateStudent)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);

            if (existingStudent == null)
            {
                return null;
            }
            
            existingStudent.StudentId = updateStudent.StudentId;
            existingStudent.FullName = updateStudent.FullName;
            existingStudent.Email = updateStudent.Email;
            existingStudent.Group = updateStudent.Group;
            existingStudent.PasswordHash = _passwordHasher.HashPassword(null!, updateStudent.Password);

            await _context.SaveChangesAsync();

            return existingStudent;
        }
    }
}
