namespace SealedClass
{
    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
    }

    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }
    }

    sealed class Executive : Employee
    {
        public string Title { get; set; }
        public double Salary { get; set; }

        public Executive()
            : base()
        {
            Title = string.Empty;
            Salary = 0;
        }
        public Executive(int id, string firstName, string lastName, string title, double salary)
            : base(id, firstName, lastName)
        {
            Title = title;
            Salary = salary;
        }

        public override double Pay()
        {
            return Salary;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(1, "Nick", "White");
            double salary = emp.Pay();
            Executive exe = new Executive(10, "Laura", "Smith", "Vice President", 235100);

            Console.WriteLine("\n*--------------------*");
            Console.WriteLine($"{emp.Fullname()}\nEmployee ID: {emp.Id}\nWeekly Salary: ${salary}");
            Console.WriteLine("*--------------------*");
            Console.WriteLine("\n*--------------------*");
            Console.WriteLine($"{exe.Fullname()}\nEmployee ID: {exe.Id}\nTitle: {exe.Title}\nYearly Salary: ${exe.Pay()}");
            Console.WriteLine("*--------------------*");
        }
    }
}
