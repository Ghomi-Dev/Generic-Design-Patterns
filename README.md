# Generic Design Patterns
Generic Design Patterns project is generic implementation of popular design patterns as .Net Standard

Separated in 3 parts

1- Creational
- [ ] Abstract Factory
- [X] Builder
- [ ] Factory Method
- [ ] Prototype
- [X] Singleton
   
2- Behavioral
- [ ] Adapter
- [ ] Bridge 
- [ ] Composite 
- [ ] Decorator 
- [ ] Facade 
- [ ] Flyweight 
- [ ] Proxy 

3- Structural
- [ ] Chain of Responsibilities
- [ ] Command 
- [ ] Interpreter 
- [ ] Iterator 
- [ ] Mediator 
- [ ] Memento 
- [ ] Observer 
- [ ] State 
- [ ] Strategy 
- [ ] Template Method 
- [ ] Visitor 

* note: implemented design patterns will be checked (to show the progress) 

## Singleton Example

    public class Student
    {
        public int Age { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
            SetStudentAge(10);
            PrintProps();
            Console.ReadKey();
        }

        private static void SetStudentAge(int ageParam)
        {
            Singleton<Student>.Instance.Age = ageParam;
        }

        static void PrintProps()
        {
            Console.WriteLine(Singleton<Student>.Instance.Age);
        }
    }


## Builder Example

    public class School
    {
        public Guid Id { get;}
        public string Name { get; set; }
        public Manager Manager { get; set; }
        public Teacher Teacher { get; set; }
    }

    public class Manager
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    public class Teacher
    {
        public string Name { get; set; }
        public string ClassroomName { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        
        private static School _school;

        static void Main(string[] args)
        {
             _school = null;
            var schoolBuilder = new Builder<School>();
            var managerBuilder = new Builder<Manager>();
            var teacherBuilder = new Builder<Teacher>();
            var students = new List<Student>();

            students.Add(new Builder<Student>().SetProperty(entity => entity.Name, "Bruce")
                .SetProperty(entity => entity.Age, 14)
                .Build());

            _school = schoolBuilder.SetProperty(entity => entity.Name, "Master School")
                .SetProperty(entity => entity.Manager, managerBuilder.SetProperty(entity => entity.Name, "John")
                    .SetProperty(entity => entity.Salary, 10000)
                    .Build())
                .SetProperty(entity => entity.Teacher, teacherBuilder.SetProperty(entity => entity.Name, "John")
                    .SetProperty(entity => entity.ClassroomName, "Classroom 1")
                    .SetProperty(entity => entity.Students, students)
                    .Build())
                .Build();

            Console.ReadKey();
        }

    }
