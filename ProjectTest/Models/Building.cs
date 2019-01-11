using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    public class Building : Base
    {
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("School")]
        public int SchoolID { get; set; }

        public School School { get; set; }
    }
}
