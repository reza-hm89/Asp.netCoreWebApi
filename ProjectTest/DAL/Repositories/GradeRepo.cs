using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;
using ProjectTest.Models.ViewModels;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTest.DAL.Repositories
{
    public class GradeRepo : GenericRepository<Grade>, IGradeRepo
    {

        ApplicationDbContext Context;

        public GradeRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }

        public bool Insert(GradeInsertModel model)
        {
            try
            {
                var grade = new Grade()
                {
                    ClassRoomID = model.ClassRoomID,
                    GPA = model.GPA,
                    StudentID = model.StudentID
                };

                var result = Add(grade);

                Log.Information("Created grade with id {0}", result.ID);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in grade insert");

                return false;
            }
        }

        public bool UpdateOne(GradeUpdateModel model, int id)
        {
            try
            {
                var grade = new Grade()
                {
                    ClassRoomID = model.ClassRoomID,
                    GPA = model.GPA,
                    StudentID = model.StudentID,
                    ID = id
                };

                Update(grade, id);

                Log.Information("Updated grade with id {0}", model.ID);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in grade update");

                return false;
            }
        }

        public bool DeleteOne(int id)
        {
            try
            {
                var grade = Get(id);
                Delete(grade);

                Log.Information("Deleted grade with id {0}", id);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in grade delete");

                return false;
            }
        }

        public IEnumerable<object> SelectAll()
        {
            try
            {
                Log.Information("Load all grades");

                return Context.Grade
                    .Include(x => x.Student)
                    .Include(x => x.ClassRoom)
                    .Select(x => new
                    {
                        x.ID,
                        x.Student.FirstName,
                        x.Student.SurName,
                        x.Student.Age,
                        x.GPA,
                        x.ClassRoom.Name
                    });
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get all grades");
                throw;
            }
        }

        public object SelectOne(int id)
        {
            try
            {
                Log.Information("Get grade with id {0}", id);

                return Context.Grade
                   .Include(x => x.Student)
                    .Include(x => x.ClassRoom)
                    .Select(x => new
                    {
                        x.ID,
                        x.Student.FirstName,
                        x.Student.SurName,
                        x.Student.Age,
                        x.GPA,
                        x.ClassRoom.Name
                    })
                   .SingleOrDefault(x => x.ID == id);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get a grade with id {0}", id);
                throw;
            }
        }
    }
}
