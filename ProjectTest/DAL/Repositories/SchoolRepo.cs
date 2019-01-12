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
    public class SchoolRepo : GenericRepository<School>, ISchoolRepo
    {

        ApplicationDbContext Context;

        public SchoolRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;

        }

        public bool Insert(SchoolInsertModel model)
        {
            try
            {
                var school = new School()
                {
                    Name = model.Name
                };

                Add(school);

                Log.Information("Created school {0}", model.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in school insert");

                return false;
            }
        }

        public bool UpdateOne(SchoolUpdateModel model, int id)
        {
            try
            {
                var school = new School()
                {
                    Name = model.Name,
                    ID = id
                };

                Update(school, id);

                Log.Information("Updated school {0}", model.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in school update");

                return false;
            }
        }

        public bool DeleteOne(int id)
        {
            try
            {
                var school = Get(id);
                Delete(school);

                Log.Information("Deleted school {0}", school.Name);

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
                Log.Information("Load all schools");

                return GetAll();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get all schools");
                throw;
            }
        }

        public School SelectOne(int id)
        {
            try
            {
                Log.Information("Get school with id {0}", id);

                return Get(id);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get all schools");
                throw;
            }
        }
    }
}
