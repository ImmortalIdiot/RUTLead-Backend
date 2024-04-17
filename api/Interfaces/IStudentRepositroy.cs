using api.Dto;
using api.Models;

namespace api.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student?> CreateAsync(Student studentModel);
        Task<Student?> UpdateAsync(int id, UpdateStudentRequestDto updateStudent);
        Task<Student?> DeleteAsync(int id);
    }
}