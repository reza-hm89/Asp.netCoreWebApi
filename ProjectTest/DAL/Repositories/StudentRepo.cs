using ProjectTest.DAL.Repositories.Interfaces;
using ProjectTest.Data;
using ProjectTest.Models;

namespace ProjectTest.DAL.Repositories
{
    public class StudentRepo : GenericRepository<Student>, IStudentRepo
    {

        ApplicationDbContext Context;

        public StudentRepo(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
