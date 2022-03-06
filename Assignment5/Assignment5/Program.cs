using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EmployeeCollection employees = new EmployeeCollection();
            while (true)
            {
                Console.WriteLine("\n\tMenu");
                Console.WriteLine("\nPress 1 Print All Employees In Ascending Order of the EmpName");
                Console.WriteLine("Press 2 Print All Employees Group by the DeptName, and also display Employee Count for each DeptName");
                Console.WriteLine("Press 3 Printing out Sum of Salary for Employess per DeptName");
                Console.WriteLine("Press 4 Printing Employee with Max Salary Per DeptName:");
                Console.WriteLine("Press 5 Printing Employee with Mininum Salary Per DeptName:");
                Console.WriteLine("Press 6 Printing Employee with Average Salary Per DeptName:");
                Console.WriteLine("Press 7 Printing Employees by Designation Group:");
                Console.WriteLine("Press 8 Printing All EMployees those are Managers, Directors only:");
                Console.WriteLine("Press 9 Printing All EMployees Having Salary in Range 25000 to 75000:");
                Console.WriteLine("Press 10 Printing Employee with Second MAx Salary Per DeptName:");
                Console.WriteLine("Press 11 Printing  Employee with Second Max Salary:");
                Console.WriteLine("Press 12 Calculate Tax for Each Employee as followas:");
                Console.WriteLine("Press 13 Modify the Employee Collection and use DeptNo instead of DeptName:");
                Console.WriteLine("Press 14 Exit:");
                Console.WriteLine();
                Console.WriteLine("Enter your choice");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {

                    case 1:
                        Ascending(employees);
                        break;
                    case 2:
                        GroupbydeptCount(employees);
                        break;

                    case 3:
                        SumSalDepname(employees);
                        break;

                    case 4:
                        MaxSalDeptname(employees);
                        break;

                    case 5:
                        MinSalDeptname(employees);
                        break;

                    case 6:
                        AvgSalDeptname(employees);
                        break;

                    case 7:
                        empdesig(employees);
                        break;

                    case 8:
                        MangDirector(employees);
                        break;

                    case 9:
                        SalRange(employees);
                        break;


                    case 10:
                        SecMaxSalDept(employees);
                        break;

                    case 11:
                        SecMaxSal(employees);
                        break;

                    case 12:
                        Tax(employees);
                        break;

                    case 13:
                        Modify(employees);
                        break;

                    case 14:
                        System.Environment.Exit(0);
                        break;

                    





                }
            }

            static void PrintResult(IEnumerable<Employee> emps)
            {
                foreach (var item in emps)
                {
                    Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName} {item.Salary} {item.Designation} {item.DeptNo}");
                }
            }

            static void Tax(IEnumerable<Employee> emp)
            {
                var tax = (from e in emp
                           group e by e.DeptName into g
                           select new
                           {
                               DeptName = g.Key,
                               record = g.ToList()
                           });
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Printing Tax for Each Employee as follows");
                Console.WriteLine("Salary from >=20K to <=40K is 0.05%");
                var Firstcase = emp.Where(e => e.Salary >= 20000 && e.Salary <= 40000);
                foreach (var item in Firstcase)
                {
                    Console.WriteLine($"The tax of {item.EmpName} is {item.Salary * 0.0005}");
                }



                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Salary from > 40K to <=60K is 0.05%");
                var Secondcase = emp.Where(e => e.Salary > 40000 && e.Salary <= 60000);
                foreach (var item in Secondcase)
                {
                    Console.WriteLine($"The tax of {item.EmpName} is {item.Salary * 0.001}");
                }


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Salary from <20k is 0");
                var Thirdcase = emp.Where(e => e.Salary < 20000);
                foreach (var item in Thirdcase)
                {
                    Console.WriteLine($"The tax of {item.EmpName} is 0");
                }


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Salary >60K is 0.15%");
                var Fourthcase = emp.Where(e => e.Salary > 60000);
                foreach (var item in Fourthcase)
                {
                    Console.WriteLine($"The tax of {item.EmpName} is {item.Salary * 0.0015}");
                }
                Console.WriteLine();
                Console.WriteLine("Print All these Salaries DeptName Wise");

                foreach (var e in tax)
                {
                    foreach (var item in e.record)
                    {
                        double amount = 0;
                        if (item.Salary >= 20000 && item.Salary <= 40000)
                        {
                            amount = (item.Salary * 0.0005);
                            Console.WriteLine($"Employee Name:{item.EmpName} , Department : {item.DeptName}, Salary:{item.Salary}, Tax:{amount}");

                        }
                        if (item.Salary > 40000 && item.Salary <= 60000)
                        {
                            amount = (item.Salary * 0.001);
                            Console.WriteLine($"Employee Name :{item.EmpName}, Department :{item.DeptName} , Salary: {item.Salary}, Tax:{amount}");
                        }
                        if (item.Salary > 60000)
                        {
                            amount = (item.Salary * 0.0015);
                            Console.WriteLine($"Employee Name:{item.EmpName}, Department:{item.DeptName}, Salary:{item.Salary}, Tax:{amount}");

                        }
                    }
                }
            }

            static void Modify(IEnumerable<Employee> emp)
            {

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Modify the Employee Collection and use DeptNo");
                DepartCollection dept = new DepartCollection();
                var Modify = (from Employee e in emp
                              join Department d in dept on e.EmpNo equals d.DeptNo
                              select new
                              {
                                  Empnumber = e.EmpNo,
                                  Name = e.EmpName,
                                  Designation = e.Designation,
                                  Department = e.DeptName,
                                  Location = d.Location,
                                  Salary = e.Salary

                              });
                foreach (var item in Modify)
                {
                    Console.WriteLine($"{item.Empnumber} {item.Name} {item.Department} {item.Designation} {item.Location} {item.Salary}");
                }

            }

            static void Ascending(IEnumerable<Employee> employees)
            {
                Console.WriteLine("Printing all record in Ascending: ");
                var orderByNameAsc = employees.OrderBy(e => e.EmpName);
                Console.WriteLine();
                PrintResult(orderByNameAsc);
            }

            static void GroupbydeptCount(IEnumerable<Employee> employees)
            {
                Console.WriteLine();
                Console.WriteLine("Printing Group by DeptName, and also display Employee Count for each DeptName:");
                var groupbydeptName = employees.GroupBy(e => e.DeptName);

                foreach (var item in groupbydeptName)
                {
                    Console.WriteLine(item.Key);
                    Console.WriteLine(item.Count());
                    PrintResult(item.ToList());
                }
            }


                static void SumSalDepname(IEnumerable<Employee> employees)
                { 
                Console.WriteLine();
                Console.WriteLine("Printing out Sum of Salary for Employess per DeptName:");
                var SumSalperDept = (from e in employees
                                     group e by e.DeptName into deptgroup
                                     select new
                                     {
                                         DeptName = deptgroup.Key,
                                         SumSalary = deptgroup.Sum(x => x.Salary)
                                     });
                foreach (var item in SumSalperDept)
                {
                    Console.WriteLine($"Group Key ={item.DeptName} and Sum of Salary={item.SumSalary}");
                }
            }

            static void MaxSalDeptname(IEnumerable<Employee> emps)
            {


                Console.WriteLine();
                Console.WriteLine("Printing Employee with Max Salary Per DeptName:");
                var HigestSalperDept = (from e in emps
                                        
                                        group e by e.DeptName into deptgroup
                                        
                                        select new
                                        {
                                            DeptName = deptgroup.Key,
                                            HighestSal = deptgroup.Max(x => x.Salary)
                                        });
                foreach (var item in HigestSalperDept)
                {
                   // PrintResult(emp);
                    
                   //Console.WriteLine($"Group Key ={item.DeptName} and Highest Salary={item.HighestSal} Employee Name:{emps.EmpName}");
                }
            }

            static void MinSalDeptname(IEnumerable<Employee> employees)
            {


                Console.WriteLine();
                Console.WriteLine("Printing Employee with Mininum Salary Per DeptName:");
                var LowestSalperDept = (from e in employees
                                        group e by e.DeptName into deptgroup
                                        select new
                                        {
                                            DeptName = deptgroup.Key,
                                            LowestSal = deptgroup.Min(x => x.Salary)
                                        });
                foreach (var item in LowestSalperDept)
                {
                    Console.WriteLine($"Group Key ={item.DeptName} and Lowest Salary={item.LowestSal}");
                }
            }

            static void AvgSalDeptname(IEnumerable<Employee> employees)
            {

                Console.WriteLine();
                Console.WriteLine("Printing Employee with Average Salary Per DeptName:");
                var AvgSalperDept = (from e in employees
                                     group e by e.DeptName into deptgroup
                                     select new
                                     {
                                         DeptName = deptgroup.Key,
                                         AvgSal = deptgroup.Average(x => x.Salary)
                                     });
                foreach (var item in AvgSalperDept)
                {
                    Console.WriteLine($"Group Key ={item.DeptName} and Lowest Salary={item.AvgSal}");
                }
            }

            static void empdesig(IEnumerable<Employee> employees)
            {

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Printing Employees by Designation Group:");
                var EmpbyDesig = (from e in employees
                                  orderby e.Designation
                                  select e);
                PrintResult(EmpbyDesig);

            }

            static void MangDirector(IEnumerable<Employee> employees)
            {

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Printing All EMployees those are Managers, Directors only:");
                var OnlymanagerDirector = employees.Where(e => e.Designation == "Manager" || e.Designation == "Director");
                PrintResult(OnlymanagerDirector);
            }


            static void SalRange(IEnumerable<Employee> employees)
            {

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Printing All EMployees Having Salary in Range 25000 to 75000:");
                var SalaryRange = employees.Where(e => e.Salary >= 25000 && e.Salary <= 75000);
                PrintResult(SalaryRange);
            }

            static void SecMaxSalDept(IEnumerable<Employee> employees)
            {

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Printing Employee with Second MAx Salary Per DeptName");
                var SecMaxSalDept = from e in employees
                                    group e by e.DeptName into g
                                    let salary = g.OrderByDescending(e => e.Salary).Skip(1).First().Salary
                                    let second = g.Where(e => e.Salary == salary)
                                    from e in second
                                    select e;
                PrintResult(SecMaxSalDept);
            }

            static void SecMaxSal(IEnumerable<Employee> employees)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Printing  Employee with Second Max Salary:");
                var SecondHighestSal = employees
                                       .GroupBy(e => e.Salary)
                                       .OrderByDescending(g => g.Key)
                                       .Skip(1)
                                       .First();
                PrintResult(SecondHighestSal);
                Console.WriteLine();
                Console.WriteLine();

            }



        }


    }
}


