using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Teacher : Base
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
