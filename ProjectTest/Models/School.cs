using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class School:Base
    {
        [StringLength(200)]
        public string Name { get; set; }
    }
}
