using Microsoft.Extensions.Logging;
using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;
using ProjectTest.Models.ViewModels;
using Serilog;
using System.Collections.Generic;

namespace ProjectTest.DAL.Repositories
{
    public class StudentRepo : GenericRepository<Student>, IStudentRepo
    {

        ApplicationDbContext Context;

        public StudentRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;

        }

        public bool Insert(StudentInsertModel model)
        {
            try
            {
                var student = new Student()
                {
                    FirstName = model.FirstName,
                    SurName = model.SurName,
                    Age = model.Age
                };

                Add(student);

                Log.Information("Created student {0}", model.SurName);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in student insert");

                return false;
            }
        }

        public bool UpdateOne(StudentUpdateModel model, int id)
        {
            try
            {
                var student = new Student()
                {
                    FirstName = model.FirstName,
                    SurName = model.SurName,
                    Age = model.Age,
                    ID = id
                };

                Update(student, id);

                Log.Information("Updated student {0}", model.SurName);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in student update");

                return false;
            }
        }

        public bool DeleteOne(int id)
        {
            try
            {
                var student = Get(id);
                Delete(student);

                Log.Information("Deleted student {0}", student.SurName);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in school delete");

                return false;
            }
        }

        public IEnumerable<object> SelectAll()
        {
            try
            {
                Log.Information("Load all students");

                return GetAll();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get all students");
                throw;
            }
        }

        public Student SelectOne(int id)
        {
            try
            {
                Log.Information("Get student with id {0}", id);

                return Get(id);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get student");
                throw;
            }
        }
    }
}
