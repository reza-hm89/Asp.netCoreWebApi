using ProjectTest.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAL
{
    public interface IUnitOfWork
    {
        IBuildingRepo Building { get; }
        IClassRoomRepo ClassRoom { get; }
        IGradeRepo Grade { get; }
        ISchoolRepo School { get; }
        IStudentRepo Student { get; }
        ITeacherRepo Teacher { get; }
    }
}
