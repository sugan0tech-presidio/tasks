namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        int _age;
        DateTime _dob;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age
        {
            get
            {
                return _age;
            } 
        }
        public DateTime DateOfBirth { get =>_dob; 
            set {
                _dob = value;
                _age =(DateTime.Today - _dob).Days/365;
            } }
        public double Salary { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
        }
        public Employee(int id, string name, DateTime dateOfBirth, double salary)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }

        public void BuildEmployeeFromConsole()
        {
            Console.Write("Please enter the Name\t:");
            Name = Console.ReadLine()??String.Empty;
            Console.Write("Please enter the Date of birth\t:");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Please enter the Basic Salary\t:");
            Salary = Convert.ToDouble(Console.ReadLine());
        }

        public void PrintEmployeeDetails()
        {
            Console.Write($"Employee Id\t:\t{Id}\n");
            Console.Write($"Employee Name\t:\t{Name}\n");
            Console.Write($"Employee DOB\t:\t{DateOfBirth}\n");
            Console.Write($"Employee Age\t:\t{Age}\n");
            Console.Write($"Employee Salary\t:\t{Salary}\n");
        }
    }
}