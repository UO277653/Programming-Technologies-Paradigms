using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08 {

    class Query {

        private Model model = new Model();

        private static void Show<T>(IEnumerable<T> collection) {
            foreach (var item in collection) {
                Console.WriteLine(item);
            }
            Console.WriteLine("Number of items in the collection: {0}.", collection.Count());
        }

        static void Main(string[] args) {
            Query query = new Query();
            //query.Query1();

            //query.Query2();

            //query.Query3();

            //query.Query4();

            //query.Homework1();

            //query.Homework2();

            //query.Homework3();

            //query.Homework4();

            query.Homework5();
        }

        private void Query1() {
            // Modify this query to show the names of the employees older than 50 years
            var employees = model.Employees.Where(x => x.Age > 50).Select(emp => emp.Name);
            Console.WriteLine("Employees:");
            Show(employees);
        }

        private void Query2() {
            // Show the name and email of the employees who work in Asturias
            //IEnumerable<String> namesAndEmails = model.Employees.Where(x => x.Province.Equals("Asturias")).Select(emp => emp.Name + " " + emp.Email);
            var namesAndEmails = model.Employees.Where(x => x.Province.ToLower().Equals("asturias")).Select(emp => new { Name = emp.Name, Email = emp.Email });
            Console.WriteLine("Employees:");
            Show(namesAndEmails);
        }

        // Notice: from now on, check out http://msdn.microsoft.com/en-us/library/9eekhta0.aspx

        private void Query3() {
            // Show the names of the departments with more than one employee 18 years old and beyond; 
            // the department should also have any office number starting with "2.1"
            var departments = model.Departments.Where(dep => dep.Employees.Where(emp => emp.Age >= 18).Count() > 1
            && dep.Employees.Count(emp => emp.Office.Number.StartsWith("2.1")) > 0).Select(dep => dep.Name);
            Console.WriteLine("Departments:");
            Show(departments);
        }

        private void Query4() {
            // Show the phone calls of each employee. 
            // Each line should show the name of the employee and the phone call duration in seconds.
            var employees = model.Employees.Join(model.PhoneCalls, x => x.TelephoneNumber,
                y => y.SourceNumber, (x, y) => new { Employee = x.Name, Call = y.Seconds });
            Console.WriteLine("Employees:");
            Show(employees);
        }

        private void Query5() {
            // Show, grouped by each province, the name of the employees 
            // (both province and employees must be lexicographically ordered)
            var employeesGroups = model.Employees.OrderBy(emp => emp.Name).GroupBy(x => x.Province).OrderBy(g => g.Key);

            foreach(var x in employeesGroups)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x)
                    Console.WriteLine("\t{0}", y.Name);
            }
        }

        /************ Homework **********************************/

        private void Homework1() {
            // Show, ordered by age, the names of the employees in the Computer Science department, 
            // who have an office in the Faculty of Science, 
            // and who have done phone calls longer than one minute

            var employees = model.Employees.Where(e => e.Office.Building.ToString().ToLower().Equals("faculty of science"))
                .Where(e => model.PhoneCalls.Any(c => c.SourceNumber.Equals(e.TelephoneNumber) && c.Seconds > 60))
                .OrderBy(e => e.Age).Select(e => e.Name);
            Console.WriteLine("Employees:");
            Show(employees);
        }

        private void Homework2() {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department

            var employeeNames = model.PhoneCalls.Where(c => model.Employees.Where(e => e.Department.Name.Equals("Computer Science"))
                .Any(e => e.TelephoneNumber.Equals(c.SourceNumber)))
                .Aggregate(0, (prev, c) => c.Seconds + prev);
                //model.Employees.Where(e => e.Department.Name.ToString().ToLower().Equals("computer science"))
                //.Any(e => e.TelephoneNumber.Equals(Sour))
                //.Aggregate(0 , (e, prev) => prev.);
            Console.WriteLine(employeeNames);
        }

        private void Homework3() {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”

            var departments = model.Departments.OrderBy(d => d.Name).Select(depart => new
            {
                Name = depart.Name,
                Duration = model.PhoneCalls.Where(c => model.Employees.Where(e => e.Department.Name.Equals(depart.Name))
                .Any(e => e.TelephoneNumber.Equals(c.SourceNumber))).Aggregate(0,(prev, c) => c.Seconds + prev)
            });

            Console.WriteLine("Departments:");
            Show(departments);
        }

        private void Homework4() {
            // Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/her age 
            // (more than one youngest employee may exist)
            var employees = model.Employees.Where(e => e.Age <= model.Employees.Aggregate(100, (minAge, e) => e.Age <= minAge ? minAge = e.Age : minAge))
                .Select(e => new { Name = e.Name, Age = e.Age });

            Console.WriteLine("Departments:");
            Show(employees);
        }

        private void Homework5() {
            // Show the greatest summation of phone call durations, in seconds, 
            // of the employees in the same department, together with the name of the department 
            // (it can be assumed that there is only one department fulfilling that condition)

            var employees = model.Departments.Select(d => new
            {
                Department = d.Name,
                Seconds = model.PhoneCalls
                .Where(c => d.Employees.Any(e => e.TelephoneNumber.Equals(c.SourceNumber)))
            .Aggregate(0, (prev, c) => c.Seconds + prev)
            }).OrderByDescending(e => e.Seconds).First();
            Console.WriteLine(employees);
        }


    }

}
