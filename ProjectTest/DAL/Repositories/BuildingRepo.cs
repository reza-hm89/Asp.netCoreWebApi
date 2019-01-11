using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;

namespace ProjectTest.DAL.Repositories
{
    public class BuildingRepo : GenericRepository<Building>, IBuildingRepo
    {

        ApplicationDbContext Context;

        public BuildingRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
