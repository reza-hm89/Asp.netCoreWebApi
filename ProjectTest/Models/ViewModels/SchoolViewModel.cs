using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models.ViewModels
{
    public class SchoolInsertModel
    {
        public string Name { get; set; }
    }
    public class SchoolUpdateModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
