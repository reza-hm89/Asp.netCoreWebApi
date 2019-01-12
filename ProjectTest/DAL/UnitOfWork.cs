using Microsoft.Extensions.Logging;

using ProjectTest.DAL.Repositories;
using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;
      
        IBuildingRepo _building;
        IClassRoomRepo _classRoom;
        IGradeRepo _grade;
        ISchoolRepo _school;
        IStudentRepo _student;
        ITeacherRepo _teacher;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
          
        }

        public IBuildingRepo Building
        {
            get
            {
                if (_building == null)
                    _building = new BuildingRepo(_context);

                return _building;
            }
        }

        public IClassRoomRepo ClassRoom
        {
            get
            {
                if (_classRoom == null)
                    _classRoom = new ClassRoomRepo(_context);

                return _classRoom;
            }
        }

        public IGradeRepo Grade
        {
            get
            {
                if (_grade == null)
                    _grade = new GradeRepo(_context);

                return _grade;
            }
        }

        public ISchoolRepo School
        {
            get
            {
                if (_school == null)
                    _school = new SchoolRepo(_context);

                return _school;
            }
        }

        public IStudentRepo Student
        {
            get
            {
                if (_student == null)
                    _student = new StudentRepo(_context);

                return _student;
            }
        }

        public ITeacherRepo Teacher
        {
            get
            {
                if (_teacher == null)
                    _teacher = new TeacherRepo(_context);

                return _teacher;
            }
        }

    }
}
