using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;

namespace ProjectTest.DAL.Repositories
{
    public class ClassRoomRepo : GenericRepository<ClassRoom>, IClassRoomRepo
    {

        ApplicationDbContext Context;

        public ClassRoomRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
