namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        private int _age;
        private DateTime _dob;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age => _age;

        /// <summary>
        ///  directly updates age with the given Date of Birth.
        /// </summary>
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

        /// <summary>
        /// Gets input from user and updates directly.
        /// </summary>
        public void BuildEmployeeFromConsole()
        {
            Console.Write("Please enter the Name\t:");
            Name = Console.ReadLine()??String.Empty;
            Console.Write("Please enter the Date of birth\t:");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            while (Age < 18)
            {
                Console.WriteLine("employee must be above 17");
                Console.Write("Please enter the Date of birth\t:");
                DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            }


            Console.Write("Please enter the Basic Salary\t:");
            Salary = Convert.ToDouble(Console.ReadLine());
        }

        public void PrintEmployeeDetails()
        {
            Console.Write($"Employee {Id} Details:\n");
            Console.Write($"\tEmployee Name\t:\t{Name}\n");
            Console.Write($"\tEmployee DOB\t:\t{DateOfBirth}\n");
            Console.Write($"\tEmployee Age\t:\t{Age}\n");
            Console.Write($"\tEmployee Salary\t:\t{Salary}\n\n");
        }
    }
}