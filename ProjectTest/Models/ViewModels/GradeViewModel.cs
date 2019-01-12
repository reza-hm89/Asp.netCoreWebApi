using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models.ViewModels
{
    public class GradeInsertModel
    {       
        public int ClassRoomID { get; set; }
      
        public int StudentID { get; set; }

        public float GPA { get; set; }
    }

    public class GradeUpdateModel
    {
        public int ID { get; set; }
      
        public int ClassRoomID { get; set; }
    
        public int StudentID { get; set; }

        public float GPA { get; set; }
    }
}
