using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.Entities;

namespace UniversityProject.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> Students { get; }
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<Instructor> Instructors { get; }
        Task Save();

    }
}
