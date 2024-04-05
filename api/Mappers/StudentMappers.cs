using api.Dto;
using api.Models;

namespace api.Mappers{
    public static class StudentMappers{
        public static StudentDto ToStudentDto(this Student studentmodel){
            return new StudentDto{
                StudentId = studentmodel.StudentId,
                Email = studentmodel.Email,
                FullName = studentmodel.FullName,
                Password = studentmodel.Password,
                Group = studentmodel.Group
            };
        }
    }
}