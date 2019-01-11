using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class ClassRoom : Base
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string RoomNO { get; set; }
        public int BuildingID { get; set; }

        public Building Building { get; set; }
    }
}
