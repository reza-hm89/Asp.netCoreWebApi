using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Student : Base
    {

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string SurName { get; set; }

        [Range(1, 120, ErrorMessage = "You must insert age between 1-120")]
        public byte Age { get; set; }
    }
}
