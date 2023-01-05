using MediatoRPattern_Core.Interfaces;
using MediatoRPattern_Core.Models;
using MediatoRPattern_Core.ResponseModels;
using MediatoRPattern_Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatoRPattern_Domain.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationPolicy policy;

        public StudentRepository(ApplicationDbContext context, ApplicationPolicy policy)
        {
            _context = context;
            this.policy = policy;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            var response = new StudentResponseModel();
            try
            {
                var result = _context.Students.Add(student);

                var dbsave = await this.policy.ImmediateHttpRetry.ExecuteAsync( () => _context.SaveChangesAsync());
                return result.Entity;

                response.Status = true;

               // return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            try
            {
                var filteredData =  _context.Students.Where(x => x.Equals(id)).FirstOrDefault();

                _context.Students.Remove(filteredData);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            try
            {
                var result =await _context.Students.Where(x => x.Equals(id)).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            //try
            //{
            //    // return await _context.Students.ToListAsync();
            //    throw new Exception();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            throw new InvalidOperationException();
        }

        public async Task<int> UpdateStudentAsync(Student student)
        {
            try
            {
                _context.Students.Update(student);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
