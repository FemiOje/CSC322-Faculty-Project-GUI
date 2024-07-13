using System.Collections.Generic;

namespace FacultyApp
{
    public static class DataStore
    {
        public static List<string> Departments { get; } = new List<string>();
        public static List<Lecturer> Lecturers { get; } = new List<Lecturer>();
    }

    public class Lecturer
    {
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
