using Microsoft.Extensions.Logging;
using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;
using ProjectTest.Models.ViewModels;
using Serilog;
using System.Collections.Generic;

namespace ProjectTest.DAL.Repositories
{
    public class TeacherRepo : GenericRepository<Teacher>, ITeacherRepo
    {

        ApplicationDbContext Context;

        public TeacherRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }

        public bool Insert(TeacherInsertModel model)
        {
            try
            {
                var teacher = new Teacher()
                {
                    Name = model.Name,
                };

                Add(teacher);

                Log.Information("Created teacher {0}", model.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in teacher insert");

                return false;
            }
        }

        public bool UpdateOne(TeacherUpdateModel model, int id)
        {
            try
            {
                var teacher = new Teacher()
                {
                    Name = model.Name,
                    ID = id
                };

                Update(teacher, id);

                Log.Information("Updated student {0}", model.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in teacher update");

                return false;
            }
        }

        public bool DeleteOne(int id)
        {
            try
            {
                var teacher = Get(id);
                Delete(teacher);

                Log.Information("Deleted teacher {0}", teacher.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in teacher delete");

                return false;
            }
        }

        public IEnumerable<object> SelectAll()
        {
            try
            {
                Log.Information("Load all teachers");

                return GetAll();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get all teachers");
                throw;
            }
        }

        public Teacher SelectOne(int id)
        {
            try
            {
                Log.Information("Get teacher with id {0}", id);

                return Get(id);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get teacher");
                throw;
            }
        }
    }
}
