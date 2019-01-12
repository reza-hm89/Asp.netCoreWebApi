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
    public class ClassRoomRepo : GenericRepository<ClassRoom>, IClassRoomRepo
    {

        ApplicationDbContext Context;

        public ClassRoomRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }

        public bool Insert(ClassInsertModel model)
        {
            try
            {
                var classRoom = new ClassRoom()
                {
                    Name = model.Name,
                    BuildingID = model.BuildingID,
                    RoomNO = model.RoomNO,
                    TeacherID = model.TeacherID
                };

                Add(classRoom);

                Log.Information("Created classRoom {0}", model.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in classRoom insert");

                return false;
            }
        }

        public bool UpdateOne(ClassUpdateModel model, int id)
        {
            try
            {
                var classRoom = new ClassRoom()
                {
                    Name = model.Name,
                    BuildingID = model.BuildingID,
                    RoomNO = model.RoomNO,
                    TeacherID = model.TeacherID,
                    ID = id
                };

                Update(classRoom, id);

                Log.Information("Updated classRoom {0}", model.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in classRoom update");

                return false;
            }
        }

        public bool DeleteOne(int id)
        {
            try
            {
                var classRoom = Get(id);
                Delete(classRoom);

                Log.Information("Deleted classRoom {0}", classRoom.Name);

                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in classRoom delete");

                return false;
            }
        }

        public IEnumerable<object> SelectAll()
        {
            try
            {
                Log.Information("Load all classRooms");

                return Context.ClassRoom
                    .Include(x => x.Building)
                    .Include(x => x.Teacher)
                    .Select(x => new
                    {
                        x.ID,
                        x.Name,
                        BuildingName = x.Building.Name,
                        x.RoomNO,
                        TeacherName = x.Teacher.Name
                    });
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get all classRooms");
                throw;
            }
        }

        public object SelectOne(int id)
        {
            try
            {
                Log.Information("Get classRoom with id {0}", id);

                return Context.ClassRoom
                   .Include(x => x.Building)
                   .Include(x => x.Teacher)
                   .Select(x => new
                   {
                       x.ID,
                       x.Name,
                       BuildingName = x.Building.Name,
                       x.RoomNO,
                       TeacherName = x.Teacher.Name
                   })
                   .SingleOrDefault(x => x.ID == id);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in get a classRoom with id {0}", id);
                throw;
            }
        }
    }
}
