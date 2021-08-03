using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.Entities;
using UniversityProject.Interfaces;

namespace UniversityProject.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Student> Students => new GenericRepository<Student>(_context);
        public IGenericRepository<Course> Courses => new GenericRepository<Course>(_context);
        public IGenericRepository<Instructor> Instructors => new GenericRepository<Instructor>(_context);

        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
