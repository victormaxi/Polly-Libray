using MediatoRPattern_Core.Interfaces;
using MediatoRPattern_Domain.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatoRPattern_Domain.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (student == null)
            {
                return default;
            }

            student.StudentName = command.StudentName;
            student.StudentEmail = command.StudentEmail;
            student.StudentAddress = command.StudentAddress;
            student.StudentAge= command.StudentAge;

            return await _studentRepository.UpdateStudentAsync(student);
        }
    }
}
