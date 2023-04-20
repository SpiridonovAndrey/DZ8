using System.Text;

namespace DZ8
{
    internal class Tree
    {
        public Node Root { get; private set; }

        public static int Count { get => Employee.Count; }

        public Tree() { }

        public Tree(Employee employee)
        {
            Root = new Node(employee);
        }

        public void Add(Employee employee)
        {
            if (Root == null)
            {
                Root = new Node(employee);
                return;
            }

            Root.Add(employee);
        }

        public void PrintStaff()
        {
            if (Root == null)
            {
                Console.WriteLine("Нет данных.");
                return;
            }
            StringBuilder stringEmployees = new StringBuilder();
            Console.WriteLine(Root.GetStaff(stringEmployees));
        }

        public void FindEmployee(int salary)
        {
            if (Root == null)
            {
                Console.WriteLine("Нет данных.");
                return;
            }

            string result = "";
            Root.FindEmployee(salary, ref result);
            Console.WriteLine(result);
        }
    }
}
