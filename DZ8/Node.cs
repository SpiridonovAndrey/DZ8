using System.Text;

namespace DZ8
{
    internal class Node : IComparable<Node>
    {
        public Employee Employee { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }
        public Node(Employee employee)
        {
            Employee = employee;
        }

        internal void Add(Employee employee)
        {
            Node current = this;
            Node node = new(employee);

            if (current.CompareTo(node) < 1)
            {
                if (current.Left == null)
                {
                    current.Left = node;
                }
                else
                {
                    current = current.Left;
                    current.Add(employee);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = node;
                }
                else
                {
                    current = current.Right;
                    current.Add(employee);
                }
            }
        }

        public int CompareTo(Node node)
        {
            return (node.Employee.Salary).CompareTo(this.Employee.Salary);
        }

        internal string GetStaff(StringBuilder stringEmployees)
        {
            Node current = this;

            if (current.Left != null)
            {
                (current.Left).GetStaff(stringEmployees);
            }

            if (current != null)
            {
                stringEmployees.Append($"{current.Employee.Name} - {current.Employee.Salary};" + Environment.NewLine);
            }

            if (current.Right != null)
            {
                (current.Right).GetStaff(stringEmployees);
            }

            return stringEmployees.ToString();
        }

        internal void FindEmployee(int salary, ref string result)
        {
            Node current = this;

            if (current.Employee.Salary == salary)
            {
                if (result != "") result = result + ", " + current.Employee.Name;
                else result = current.Employee.Name;
            }

            if (salary <= current.Employee.Salary)
            {
                if (current.Left == null)
                {
                    if(result == "") result = "Такой сотрудник не найден!";
                }
                else
                {
                    current = current.Left;
                    current.FindEmployee(salary, ref result);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    if (result == "") result = "Такой сотрудник не найден!";
                }
                else
                {
                    current = current.Right;
                    current.FindEmployee(salary, ref result);
                }
            }
        }
    }
}
