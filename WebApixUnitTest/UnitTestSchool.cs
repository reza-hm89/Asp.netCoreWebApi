using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectTest.Controllers;
using ProjectTest.DAL;
using ProjectTest.DAL.Repositories;
using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WebApixUnitTest
{
    public class UnitTestSchool
    {
        private readonly ISchoolRepo _service;
        ApplicationDbContext _context;
        public UnitTestSchool()
        {
            InitContext();
        }

        public void InitContext()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase();

            var context = new ApplicationDbContext(builder.Options);
            var schools = Enumerable.Range(1, 10)
                .Select(i => new School { Name = "Schools for test" });
            context.School.AddRange(schools);
            int changed = context.SaveChanges();
            _context = context;
        }

        [Fact]
        public void Gets_WhenCalled_ReturnsObjects()
        {
            // Arrange            
            var s = new SchoolRepo(_context);

            // Act
            var okResult = s.SelectAll();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<School>>(okResult);
        }

        [Fact]
        public void Gets_WhenCalled_ReturnSchoolModel()
        {
            // Arrange            
            var s = new SchoolRepo(_context);

            // Act
            var okResult = s.SelectOne(11);

            // Assert
            Assert.IsType<School>(okResult);
        }

        [Fact]
        public void Gets_WhenCalled_ReturnNull()
        {
            // Arrange            
            var s = new SchoolRepo(_context);

            // Act
            var okResult = s.SelectOne(11);

            // Assert
            Assert.Null(okResult);
        }

        [Fact]
        public void Insert_WhenCalled_ReturnTrueResult()
        {
            // Arrange            
            var s = new SchoolRepo(_context);

            // Act
            var okResult = s.Insert(new ProjectTest.Models.ViewModels.SchoolInsertModel() { Name = "school for test" });

            // Assert
            Assert.True(okResult);
        }

        [Fact]
        public void Update_WhenCalled_ReturnTrueResult()
        {
            // Arrange            
            var s = new SchoolRepo(_context);

            // Act
            var okResult = s.UpdateOne(new ProjectTest.Models.ViewModels.SchoolUpdateModel() { Name = "school for test" }, 10);

            // Assert
            Assert.True(okResult);
        }

        [Fact]
        public void Update_WhenCalled_ReturnFalseResult()
        {
            // Arrange            
            var s = new SchoolRepo(_context);

            // Act
            var okResult = s.UpdateOne(new ProjectTest.Models.ViewModels.SchoolUpdateModel() { Name = "school for test" }, 15);

            // Assert
            Assert.False(okResult);
        }

        [Fact]
        public void Delete_WhenCalled_ReturnTrueResult()
        {
            // Arrange            
            var s = new SchoolRepo(_context);

            // Act
            var okResult = s.DeleteOne(10);

            // Assert
            Assert.True(okResult);
        }

        [Fact]
        public void Delete_WhenCalled_ReturnFalseResult()
        {
            // Arrange            
            var s = new SchoolRepo(_context);

            // Act
            var okResult = s.DeleteOne(15);

            // Assert
            Assert.False(okResult);
        }
    }
}
