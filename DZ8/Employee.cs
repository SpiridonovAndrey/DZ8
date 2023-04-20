namespace DZ8
{
    internal class Employee
    {
        public string Name { get; private set; }
        public int Salary { get; private set; }
        public static int Count { get; private set; }
        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
            Count++;
        }
    }
}
