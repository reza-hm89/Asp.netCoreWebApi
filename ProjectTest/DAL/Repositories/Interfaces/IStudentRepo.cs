using ProjectTest.Models;
using ProjectTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAL.Repositories.Interfaces
{
    public interface IStudentRepo
    {
        bool Insert(StudentInsertModel model);
        bool UpdateOne(StudentUpdateModel model, int id);
        bool DeleteOne(int id);
        IEnumerable<object> SelectAll();
        Student SelectOne(int id);
    }
}
