using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;

namespace ProjectTest.DAL.Repositories
{
    public class GradeRepo : GenericRepository<Grade>, IGradeRepo
    {

        ApplicationDbContext Context;

        public GradeRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
