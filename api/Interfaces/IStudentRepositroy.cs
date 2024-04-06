using api.Models;

namespace api.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllSync();
    }
}