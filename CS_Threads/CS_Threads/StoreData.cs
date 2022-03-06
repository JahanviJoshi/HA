using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Threads
{
    internal class StoreData
    {

        public void WriteDataToDb(Employee employee)
        {
            try
            {
                SqlConnection Conn = new SqlConnection("Data Source = .;Initial Catalog=Demo;Integrated Security=SSPI");
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Employee0", Conn);
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "Employee");
                DataRow Dr = Ds.Tables["Employee"].NewRow();
                Dr["Empno"] = employee.Empno;
                Dr["Empname"] = employee.Empname;
                Dr["Salary"] = employee.Salary;
                Dr["Designation"] = employee.Designation;
                Dr["Email"] = employee.Email;
                Dr["Deptno"] = employee.Deptno;

                Ds.Tables["Employee"].Rows.Add(Dr);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(Ds, "Employee");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void ReadDataToDb(int id)
        {
            try {
                SqlConnection Conn = new SqlConnection("Data Source = .;Initial Catalog=Demo;Integrated Security = SSPI");
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Employee",Conn);
                sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet DS = new DataSet();
                sqlDataAdapter.Fill(DS, "Employee");
                Console.WriteLine("Data of Employee Table");
                DataRow row = DS.Tables["Employee"].Rows.Find(id);
                Console.WriteLine($"{row?["Empno"]}   {row?["EmpName"]}       {row?["salary"]}       {row?["Designation"]}    {row?["DeptNo"]}    {row?["Email"]}")

            
            
            
            
            
            
            
            
            
            
            }
            catch(Exception ex) { }
        }
    }
}
