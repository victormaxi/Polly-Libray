using MediatoRPattern_Core.Models;
using MediatoRPattern_Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatoRPattern_Core.Interfaces
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<Student> AddStudentAsync(Student student);
        public Task<int> UpdateStudentAsync(Student student);
        public Task<int> DeleteStudentAsync(int id);
    }
}
