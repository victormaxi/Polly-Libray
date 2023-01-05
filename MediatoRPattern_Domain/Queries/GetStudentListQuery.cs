using MediatoRPattern_Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatoRPattern_Domain.Queries
{
    public class GetStudentListQuery : IRequest<List<Student>>
    {
    }
}
