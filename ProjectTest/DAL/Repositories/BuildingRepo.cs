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
    public class BuildingRepo : GenericRepository<Building>, IBuildingRepo
    {

        ApplicationDbContext Context;

        public BuildingRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }

        public bool Insert(BuildingInsertModel model)
        {
            try
            {
                var building = new Building()
                {
                    Name = model.Name,
                    SchoolID = model.SchoolID
                };

                Add(building);

                Log.Information("Created building {0}", model.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in building insert");

                return false;
            }
        }

        public bool UpdateOne(BuildingUpdateModel model, int id)
        {
            try
            {
                var building = new Building()
                {
                    Name = model.Name,
                    SchoolID = model.SchoolID
                };

                Update(building, id);

                Log.Information("Updated building {0}", model.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in building update");

                return false;
            }
        }

        public bool DeleteOne(int id)
        {
            try
            {
                var building = Get(id);
                if (building != null)
                {
                    Delete(building);

                    Log.Information("Deleted building {0}", building.Name);

                    return true;
                }

                else
                {
                    Log.Information("building {0} not found", building.Name);

                    return false;
                }

            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in building delete");

                return false;
            }
        }

        public IEnumerable<object> SelectAll()
        {
            try
            {
                Log.Information("Load all buildings");

                return Context.Building
                    .Include(x => x.School)
                    .Select(x => new { x.ID, x.Name, SchoolName = x.School.Name });
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get all buildings");
                throw;
            }
        }

        public object SelectOne(int id)
        {
            try
            {
                Log.Information("Get building with id {0}", id);

                return Context.Building
                   .Include(x => x.School)
                   .Select(x => new { x.ID, x.Name, SchoolName = x.School.Name })
                   .SingleOrDefault(x => x.ID == id);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get all buildings");
                throw;
            }
        }
    }
}
