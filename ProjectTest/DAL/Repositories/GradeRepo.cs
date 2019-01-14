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
                if (grade != null)
                {
                    Delete(grade);

                    Log.Information("Deleted grade with id {0}", id);

                    return true;
                }

                else
                {
                    Log.Information("grade record with id {0} not found", id);

                    return false;
                }

            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in grade delete");

                return false;
            }
        }

        public IEnumerable<object> SelectAllByClassRoom(int classID)
        {
            try
            {
                Log.Information("Load all grades in the class");

                var query = from c in Context.ClassRoom
                            where c.ID == classID
                            select new
                            {
                                ClassName = c.Name,
                                Grades = from g in Context.Grade
                                         join s in Context.Student on g.StudentID equals s.ID
                                         where g.ClassRoomID == classID
                                         select new { s.FirstName, s.SurName, s.Age, g.GPA, g.ID }
                            };

                return query;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get all grades in the class");
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

        public bool ExistSurnameInClass(int classID, string surName)
        {
            try
            {
                return Context.Grade.Include(x => x.Student).Any(x => x.ClassRoomID == classID && x.Student.SurName.Equals(surName));
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in exist sruname in classRoom with id {0} and surname {1}", classID, surName);
                throw;
            }
        }
    }
}
