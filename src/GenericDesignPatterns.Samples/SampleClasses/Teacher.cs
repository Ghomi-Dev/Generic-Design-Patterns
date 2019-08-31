using System.Collections.Generic;

namespace GenericDesignPatterns.Samples.SampleClasses
{
    /// <summary>
    /// Student : Sample Class for tests
    /// </summary>
    public class Teacher
    {
        public string Name { get; set; }
        public string ClassroomName { get; set; }
        public List<Student> Students { get; set; }
    }
}
