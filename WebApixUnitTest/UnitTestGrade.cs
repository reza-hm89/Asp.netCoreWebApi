using Microsoft.EntityFrameworkCore;
using ProjectTest.DAL.Repositories;
using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace WebApixUnitTest
{
    public class UnitTestGrade
    {
        private readonly IGradeRepo _service;
        ApplicationDbContext _context;
        public UnitTestGrade()
        {
            InitContext();
        }

        public void InitContext()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase();

            var context = new ApplicationDbContext(builder.Options);

            var teacher = Enumerable.Range(1, 3)
              .Select(i => new Teacher { Name = "teacher" });

            var students = Enumerable.Range(1, 3)
               .Select(i => new Student { FirstName = "first", SurName = "surname", Age = 20 });

            var school = Enumerable.Range(1, 1)
             .Select(i => new School { Name = "school" });

            var buildings = Enumerable.Range(1, 3)
              .Select(i => new Building { Name = "Building", SchoolID = 1 });

            var classes = Enumerable.Range(1, 3)
            .Select(i => new ClassRoom { Name = "class", BuildingID = 1, RoomNO = "Room 1", TeacherID = 1 });

            var grades = Enumerable.Range(1, 10)
                .Select(i => new Grade { ClassRoomID = 1, GPA = 1, StudentID = 1 });

            context.School.AddRange(school);
            context.Building.AddRange(buildings);
            context.Student.AddRange(students);
            context.Teacher.AddRange(teacher);
            context.ClassRoom.AddRange(classes);
            context.Grade.AddRange(grades);

            int changed = context.SaveChanges();
            _context = context;
        }

        [Fact]
        public void Gets_WhenCalled_ReturnsObjects()
        {
            // Arrange            
            var s = new GradeRepo(_context);

            // Act
            var okResult = s.SelectAllByClassRoom(1);

            // Assert
            Assert.IsAssignableFrom<IEnumerable<object>>(okResult);
        }

        [Fact]
        public void Insert_WhenCalled_ReturnObject()
        {
            // Arrange            
            var s = new GradeRepo(_context);

            // Act
            var okResult = s.Add(new Grade() { ClassRoomID = 1, GPA = 2, StudentID = 1 });

            // Assert
            Assert.IsType<Grade>(okResult);
        }

        [Fact]
        public void Update_WhenCalled_ReturnObject()
        {
            // Arrange            
            var s = new GradeRepo(_context);

            // Act
            var okResult = s.Update(new Grade() { ID = 1, ClassRoomID = 1, GPA = 2, StudentID = 1 }, 1);

            // Assert
            Assert.IsType<Grade>(okResult);
        }

        [Fact]
        public void Delete_WhenCalled_ReturnTrue()
        {
            // Arrange            
            var s = new GradeRepo(_context);

            // Act
            var okResult = s.DeleteOne(1);

            // Assert
            Assert.True(okResult);
        }

        [Fact]
        public void Delete_WhenCalled_ReturnFalse()
        {
            // Arrange            
            var s = new GradeRepo(_context);

            // Act
            var okResult = s.DeleteOne(10);

            // Assert
            Assert.True(okResult);
        }
    }
}
