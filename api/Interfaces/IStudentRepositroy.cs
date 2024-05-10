using api.Dto;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(QueryObject queryObject);
        Task<Student?> GetByIdAsync(int id);
        Task<Student?> CreateAsync(Student studentModel);
        Task<Student?> UpdateAsync(int id, UpdateStudentRequestDto updateStudent);
        Task<Student?> DeleteAsync(int id);
    }
}
