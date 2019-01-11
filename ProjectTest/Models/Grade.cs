using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    public class Grade : Base
    {
        [ForeignKey("ClassRoom")]
        public int ClassRoomID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        public float GPA { get; set; }

        public Student Student { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}
