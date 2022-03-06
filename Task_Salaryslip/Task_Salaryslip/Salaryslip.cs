using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Salaryslip
{
    internal class Salaryslip
    {
        public void fileCreate(Employee emp, double HRA, double TA, double DA, double gross, double NetSalary, double tax, int MonthlyNetSalary)
        {
            string path = @"C:\Coditas\Salaryslip";
            string filePath = $@"{path} {emp.EmpNo}.txt";
            if (File.Exists(filePath))
            {

                Console.WriteLine($" file {filePath} is already exists");
            }


            FileStream F = File.Create(filePath);
            byte[] content = new UTF8Encoding(true).GetBytes(
                           $"-------------------------Salary Slip--------------------------\n" +
                           $"| EmpNo:    {emp.EmpNo}                 EmpName: {emp.EmpName}                |\n" +
                           $"| DeptName: {emp.DeptName}              Designation: {emp.Designation}            |\n" +
                           $"|____________________________________________________________|\n" +
                           $"|Income (Rs.)                  | Deduction (Rs.)             |\n" +
                           $"|------------------------------------------------------------|\n" +
                           $"|Basic Salary: {emp.Salary}            |                             |\n" +
                           $"|HRA: {HRA}                      |                             |\n" +
                           $"|TA: {TA}                      |                             |\n" +
                           $"|DA: {DA}                      |                             |\n" +
                           $"|------------------------------------------------------------|\n" +
                           $"|Gross: {gross}                 |                             |\n" +
                           $"|------------------------------------------------------------|\n" +
                           $"|AnualGross:{NetSalary}            | Tax: {tax}                  |\n" +
                           $"|------------------------------------------------------------|\n" +
                           $"|NetSalary: {MonthlyNetSalary}              |                             |\n" +
                           $"|------------------------------------------------------------|\n" +
                           $"|NetSalary in Words:{Program.NumberToWords(MonthlyNetSalary)}                                         |\n" +
                           $"--------------------------------------------------------------");


            F.Write(content, 0, content.Length);
            F.Close();
        }

        public  void writeData(string filePath, Employee emp, double HRA, double TA, double DA, double gross, double NetSalary, double tax, int MonthlyNetSalary)
        {
            string content = $"-------------------------Salary Slip--------------------------\n" +
                               $"| EmpNo: {emp.EmpNo}            EmpName: {emp.EmpName}       |\n" +
                               $"| DeptName: {emp.DeptName}   Designation: {emp.Designation}  |\n" +
                               $"|____________________________________________________________|\n" +
                               $"|Income (Rs.)                  | Deduction (Rs.)             |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|Basic Salary: {emp.Salary}    |                             |\n" +
                               $"|HRA: {HRA}                    |                             |\n" +
                               $"|TA: {TA}                      |                             |\n" +
                               $"|DA: {DA}                      |                             |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|Gross: {gross}                |                             |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|AnualGross:{NetSalary} | Tax: {tax}                  |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|NetSalary: {MonthlyNetSalary} |                             |\n" +
                               $"|------------------------------------------------------------|\n" +
                               $"|NetSalary in Words:{Program.NumberToWords(MonthlyNetSalary)}                                          |\n" +
                               $"--------------------------------------------------------------";

            File.Create(filePath);
            File.WriteAllText(filePath, content);




        }

        public void Copyfile()
        {

            string[] filePaths = Directory.GetFiles(@"C:\Coditas\Salaryslip");
            foreach (var filename in filePaths)
            {
                string file1 = filename.ToString();

                //Do your job with "file"  
                string str = "Your Destination" + file1.ToString(), Replace(@"C:\College");
                if (!File.Exists(str))
                {
                    File.Copy(file1, str);
                }
            }
          

        }


    }

    
}
