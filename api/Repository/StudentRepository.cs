using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApiDBContext _context;
        public StudentRepository(ApiDBContext context) 
            {
                _context = context;
            }

        public Task<List<Student>> GetAllSync()
        {
            return _context.Students.ToListAsync();
        }
    }
}