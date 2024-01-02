using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using WebApplication_01.Models;

namespace WebApplication_01.Controllers
{
    public class MapperController : Controller
    {
        public IActionResult Index()
        {
            var student = new Student
            {
                Id = 10,
                FirstName = "Ali",
                LastName = "Lotfi"
            };

            var mappingConfig = new MapperConfiguration(p =>
            {
                p.CreateMap<Student, StudentDto>();
            });

            //var mapper = mappingConfig.CreateMapper();

            //var studentDto = mapper.Map<StudentDto>(student);

            //var studentDto = MapTo<Student, StudentDto>(student);


            var students = new List<Student>
            {
                new Student {Id = 1, FirstName = "Ali", LastName = "lotfi"},
                new Student {Id = 1, FirstName = "Ali", LastName = "lotfi"},
                new Student {Id = 1, FirstName = "Ali", LastName = "lotfi"},
                new Student {Id = 1, FirstName = "Ali", LastName = "lotfi"},
            };

            var studentDtos = students
                               .AsQueryable()
                               .ProjectTo<StudentDto>(mappingConfig)
                               .ToList();


            return View();
        }

        private static TDto MapTo<TEntity, TDto>(TEntity entity)
        {
            var mappingConfig = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDto>();
            });

            var mapper = mappingConfig.CreateMapper();

            return mapper.Map<TDto>(entity);
        }

    }
}
