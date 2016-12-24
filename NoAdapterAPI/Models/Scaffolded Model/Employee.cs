namespace NoAdapterAPI.Models
{
    public partial class Employee
    {       
        public int EmployeeID { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Extra { get; set; }
        public string Classification { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double WorkingHours { get; set; }
        public int WorkingAt { get; set; }
        public int SupervisorID { get; set; }
    }
}
