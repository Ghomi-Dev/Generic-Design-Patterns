using System;

namespace GenericDesignPatterns.Samples.SampleClasses
{
    /// <summary>
    /// Student : Sample Class for tests
    /// </summary>
    public class School
    {
        public Guid Id { get; } = new Guid();

        public string Name { get; set; }
        public Manager Manager { get; set; }
        public Teacher Teacher { get; set; }
    }
}
