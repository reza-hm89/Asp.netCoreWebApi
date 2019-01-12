using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models.ViewModels
{
    public class BuildingInsertModel
    {
        [StringLength(50)]
        public string Name { get; set; }

        public int SchoolID { get; set; }
    }

    public class BuildingUpdateModel
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int SchoolID { get; set; }
    }
}
