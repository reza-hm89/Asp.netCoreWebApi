using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models.ViewModels
{
    public class StudentInsertModel
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        [Range(1, 120, ErrorMessage = "You must insert age between 1-120")]
        public byte Age { get; set; }
    }
    public class StudentUpdateModel
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }

        [Range(1, 120, ErrorMessage = "You must insert age between 1-120")]
        public byte Age { get; set; }
        public int ID { get; set; }
    }
}
