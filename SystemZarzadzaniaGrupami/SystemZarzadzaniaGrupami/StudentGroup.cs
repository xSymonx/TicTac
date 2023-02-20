using System.Collections.Generic;

namespace StudentGroups
{
    public class StudentGroup
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public StudentGroup()
        {
            Students = new List<Student>();
        }
    }
}