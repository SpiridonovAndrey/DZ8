namespace DZ8
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите информацию о сотрудниках (имя+зарплата).");
            Tree tree = Staff();
            Console.WriteLine("Введите размер зарплаты, искомого сотрудника.");
            FindEmployee(ref tree);

            while (true)
            {
                Console.WriteLine("Нажмите - 0 если хотите начать всё сначала, 1 - если хотите продолжить поиск по зарплате или любую другую клавишу для завершения программы.");
                switch (Console.ReadLine())
                {
                    case "0":
                        {
                            Console.Clear();
                            Console.WriteLine("Введите информацию о сотрудниках (имя+зарплата).");
                            tree = Staff();
                            Console.WriteLine("Введите размер зарплаты, искомого сотрудника.");
                            FindEmployee(ref tree);
                            break;
                        }
                    case "1":
                        {
                            Console.WriteLine("Введите размер зарплаты, искомого сотрудника:");
                            FindEmployee(ref tree);
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Завершение программы.");
                            return;
                        }
                }
            }
        }
        private static Tree Staff()
        {
            string name = Console.ReadLine();
            Tree tree = new();
            while (name != "")
            {
                Employee employee = new(name, EmployeeSalary());

                tree.Add(employee);

                Console.WriteLine("Cледующий сотрудник и его зарплата или нажмите Enter для окончания ввода сотрудников:");
                name = Console.ReadLine();
            }
            tree.PrintStaff();
            return tree;
        }

        private static int EmployeeSalary()
        {
            int salary = 0;
            while (salary <= 0)
            {
                if (int.TryParse(Console.ReadLine(), out salary) && salary>0)
                {
                    return salary;
                }
                else
                {
                    Console.WriteLine("Зарплата должна быть положительным целым числом");
                    Console.WriteLine("Введите зарплату сотрудника:");
                }
            }
            return salary;
        }

        private static void FindEmployee(ref Tree tree)
        {
            tree.FindEmployee(EmployeeSalary());
        }
    }
}