using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models.ViewModels
{
    public class ClassInsertModel
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string RoomNO { get; set; }
        public int BuildingID { get; set; }
        public int TeacherID { get; set; }
    }

    public class ClassUpdateModel
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string RoomNO { get; set; }
        public int BuildingID { get; set; }
        public int TeacherID { get; set; }
    }
}
