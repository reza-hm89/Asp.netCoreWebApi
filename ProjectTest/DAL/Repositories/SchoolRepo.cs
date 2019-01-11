using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;

namespace ProjectTest.DAL.Repositories
{
    public class SchoolRepo : GenericRepository<School>, ISchoolRepo
    {

        ApplicationDbContext Context;

        public SchoolRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
