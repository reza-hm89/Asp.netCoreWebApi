using ProjectTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAL.Repositories.Interfaces
{
    public interface IGradeRepo
    {
        bool Insert(GradeInsertModel model);
        bool UpdateOne(GradeUpdateModel model, int id);
        bool DeleteOne(int id);
        IEnumerable<object> SelectAll();
        object SelectOne(int id);
    }
}
