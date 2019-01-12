using ProjectTest.Models;
using ProjectTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAL.Repositories.Interfaces
{
    public interface IBuildingRepo
    {
        bool Insert(BuildingInsertModel model);
        bool UpdateOne(BuildingUpdateModel model, int id);
        bool DeleteOne(int id);
        IEnumerable<object> SelectAll();
        object SelectOne(int id);
    }
}
