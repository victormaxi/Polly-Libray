using MediatoRPattern_Core.Interfaces;
using MediatoRPattern_Core.Models;
using MediatoRPattern_Domain.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatoRPattern_Domain.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository= studentRepository;
        }
        public async Task<Student> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = new Student()
            {
                StudentAddress = command.StudentAddress,
                StudentAge = command.StudentAge,
                StudentEmail = command.StudentEmail,
                StudentName = command.StudentName,
            };

            return await _studentRepository.AddStudentAsync(student);
        }
    }
}
