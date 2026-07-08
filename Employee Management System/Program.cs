using System;
namespace EmployeeManagement
{
    class Program
    {
        List<Employee> employees = new List<Employee>();
        static void Main(string[] args)
        {
            Program program = new Program();
            bool run_program = true;
            while (run_program)
            {
                Console.WriteLine("1. Add Employee\n" +
               "2. List Employee\n" +
               "3. Search Employee\n" +
               "4. Give Raise\n" +
               "5. Remove Employee\n" +
               "6. Exit");

                Console.Write("Input: ");
                int input = program.NumberValidation(Console.ReadLine());
                // switch statement for user input 
                switch(input)
                {
                    case 1:
                        // Add an Employee 
                        program.AddEmployee();
                        break;
                    case 2:
                        // List all employees
                        program.ListEmployees();
                        break;
                    case 3:
                        // Search for an employee
                        program.SearchEmployees();
                        break;
                    case 4:
                        // Give an employee a raise
                        program.GiveRaise();
                        break;
                    case 5:
                        // remove or fire an employee 
                        program.RemoveEmployee();
                        break;
                    case 6:
                        // End program
                        run_program = false;
                        break;
                }
            }
        }

        #region Number Validation

        int NumberValidation(string input)
        {
            int number = 0;
            while (true)
            {
                while(string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input can not be empty");
                    input = Console.ReadLine();
                }
                if (int.TryParse(input, out number))
                {
                    return number;
                }
                Console.WriteLine("Enter a valid number");
                input = Console.ReadLine();
            }
        }
        #endregion

        #region Input Validation
        string InputValidation(string input)
        {
            while(string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input can not be empty");
                input = Console.ReadLine();
            }
            return input;
        }

        #endregion

        #region Add Employee
        void AddEmployee()
        {
            Console.WriteLine("How many employees do you want to enter?");
            int number = NumberValidation(Console.ReadLine());
            // add the amount of employees based on user input
            for (int i = 0; i < number; i++)
            {
                Employee employee = new Employee();
                Console.WriteLine("Enter employee name");
                string name = InputValidation(Console.ReadLine());
                employee.Name = name;
                Console.WriteLine("Enter employee ID");
                int ID = NumberValidation(Console.ReadLine());
                employee.EmployeeID = ID;
                Console.WriteLine("Enter employee department");
                string department = InputValidation(Console.ReadLine());
                employee.Department = department;
                Console.WriteLine("Enter employee salary");
                int salary = NumberValidation(Console.ReadLine());
                employee.Salary = salary;
                employees.Add(employee);
                Console.WriteLine("Employee added!");
            }
        }
        #endregion

        #region List All Employees
        void ListEmployees()
        {
            //list each employee 
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Employee Name: {employee.Name}");
                Console.WriteLine($"Employee Department: {employee.Department}");
                Console.WriteLine($"Employee ID: {employee.EmployeeID}");
                Console.WriteLine($"Employee Salary: {employee.Salary}");
            }
        }
        #endregion

        #region Search Employees 
        void SearchEmployees()
        {
            Console.WriteLine("Enter the name of the employee that you are looking for");
            string Search = InputValidation(Console.ReadLine());
            bool EmployeeFound = false;
            // search through each employee until a name match 
            foreach (Employee emp in employees)
            {
                if (emp.Name.ToLower().Contains(Search))
                {
                    Console.WriteLine($"Employee Name: {emp.Name}");
                    Console.WriteLine($"Employee ID: {emp.EmployeeID}");
                    Console.WriteLine($"Employee Department: {emp.Department}");
                    Console.WriteLine($"Employee Salary: {emp.Salary}");
                    EmployeeFound = true;
                }
            }
            if (!EmployeeFound)
            {
                Console.WriteLine("Employee not found");
            }
        }

        #endregion

        #region Give Employee Raise
        void GiveRaise()
        {
            Console.WriteLine("Enter the name of the employee you want to give a raise to");
            string Name = InputValidation(Console.ReadLine());
            bool EmployeeFound = false;
            // cycle through employees until name match 
            foreach (Employee emp in employees)
            {
                if (emp.Name.ToLower().Contains(Name)) 
                {
                    EmployeeFound = true;
                    Console.WriteLine($"Employee Name: {emp.Name}");
                    Console.WriteLine($"Current Salary: {emp.Salary}");
                    Console.Write("New Salary: ");
                    int NewSalary = NumberValidation(Console.ReadLine());
                    emp.Salary = NewSalary;
                    Console.WriteLine($"Employees new salary is {emp.Salary}");
                }
            }
            if (!EmployeeFound)
            {
                Console.WriteLine("Employee not found");
            }
        }
        #endregion

        #region Remove Employee
        void RemoveEmployee()
        {
            Console.WriteLine("Enter the name of the employee that you want to remove");
            string Name = InputValidation(Console.ReadLine());
            bool FoundEmployee = false;
            // loop through employees
            for (int i = 0; i < employees.Count; i++)
            {
               if (employees[i].Name.ToLower().Contains(Name))
                {
                    FoundEmployee = true;
                    employees.RemoveAt(i);
                    break;
                }
            }
            if (!FoundEmployee)
            {
                Console.WriteLine("Employee not found");
            } 
        }
        #endregion

    }
}