using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.Entities;
using UniversityProject.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityProject.Controllers
{
    public class StudentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _unitOfWork.Students.FindAll();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await _unitOfWork.Students.Find(expression: q => q.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task Post()
        {
            var instructor = new Instructor()
            {
                Firstname = "Elcin",
                Lastname = "Aysecikturk"
            };

            await _unitOfWork.Instructors.Create(instructor);
            await _unitOfWork.Save();

            var instructortemp = await _unitOfWork.Instructors.Find(x => x.Lastname == "Aysecikturk");

            var course = new Course()
            {
                Name = "BLOB101",
                Instructor = instructortemp
            };

            await _unitOfWork.Courses.Create(course);
            await _unitOfWork.Save();

            var student = new Student()
            {
                Firstname = "Boe",
                Lastname = "Tiju",
            };

            student.Courses = new List<Course>();
            student.Courses.Add(course);

            await _unitOfWork.Students.Create(student);
            await _unitOfWork.Save();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
