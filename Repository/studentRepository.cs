using Entities.Models;
using Entities;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contracts.Contracts;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class StudentRepostiory : RepositoryBase<Student>, IstudentRepository
    {
        public StudentRepostiory(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<PagedList<Student>> GetStudentsAsync(Guid AyditoryaId, StudentParameters studentParameters, bool trackChanges)
        {
            var students = await FindByCondition(e => e.ayditorya.Equals(AyditoryaId) && (e.Age >= studentParameters.MinAge && e.Age <= studentParameters.MaxAge), trackChanges)
                .OrderBy(e => e.Name)
                .ToListAsync();
            return PagedList<Student>
                .ToPagedList(students, studentParameters.PageNumber, studentParameters.PageSize);
        }


        public async Task<Student> GetStudentAsync(Guid AyditoryaId, Guid id, bool trackChanges) => await FindByCondition(e => e.ayditoryaId.Equals(AyditoryaId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
        public void CreateStudentForAyditorya(Guid AyditoryaId, Student student)
        {
            student.ayditoryaId = AyditoryaId;
            Create(student);
        }
        public void DeleteStudent(Student student)
        {
            Delete(student);
        }
    }
}
