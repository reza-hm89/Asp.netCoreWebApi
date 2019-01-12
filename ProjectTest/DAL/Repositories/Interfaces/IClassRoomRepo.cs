using ProjectTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAL.Repositories.Interfaces
{
    public interface IClassRoomRepo
    {
        bool Insert(ClassInsertModel model);
        bool UpdateOne(ClassUpdateModel model, int id);
        bool DeleteOne(int id);
        IEnumerable<object> SelectAll();
        object SelectOne(int id);
    }
}
