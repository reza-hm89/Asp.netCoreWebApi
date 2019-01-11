using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;

namespace ProjectTest.DAL.Repositories
{
    public class TeacherRepo : GenericRepository<Teacher>, ITeacherRepo
    {

        ApplicationDbContext Context;

        public TeacherRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
