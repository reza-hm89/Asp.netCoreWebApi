using ProjectTest.Models;
using ProjectTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAL.Repositories.Interfaces
{
    public interface ISchoolRepo
    {
        bool Insert(SchoolInsertModel model);
        bool UpdateOne(SchoolUpdateModel model, int id);
        bool DeleteOne(int id);
        IEnumerable<object> SelectAll();
        School SelectOne(int id);
    }
}
