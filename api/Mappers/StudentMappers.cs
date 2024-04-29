using api.Dto;
using api.Models;

namespace api.Mappers{
    public static class StudentMappers{
        public static StudentDto ToStudentDto(this Student studentmodel){
            return new StudentDto{
                StudentId = studentmodel.StudentId,
                Email = studentmodel.Email,
                FullName = studentmodel.FullName,
                Password = studentmodel.PasswordHash,
                Group = studentmodel.Group
            };
        }

        public static Student ToStudentFromCreate(this CreateStudentRequestDto studentDto)
        {
            return new Student
            {
                StudentId = studentDto.StudentId,
                Email = studentDto.Email,
                FullName = studentDto.FullName,
                PasswordHash = studentDto.Password,
                Group = studentDto.Group
            };
        }
    }
}
