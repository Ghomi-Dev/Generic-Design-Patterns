# Generic Design Patterns
Generic Design Patterns project is generic implementation of popular design patterns as .Net Standard

Separated in 3 parts

1- Creational
- [ ] Abstract Factory
- [ ] Builder
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

