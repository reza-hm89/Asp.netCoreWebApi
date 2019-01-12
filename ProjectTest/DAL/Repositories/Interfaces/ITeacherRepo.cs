using ProjectTest.Models;
using ProjectTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAL.Repositories.Interfaces
{
    public interface ITeacherRepo
    {
        bool Insert(TeacherInsertModel model);
        bool UpdateOne(TeacherUpdateModel model, int id);
        bool DeleteOne(int id);
        IEnumerable<object> SelectAll();
        Teacher SelectOne(int id);
    }
}
