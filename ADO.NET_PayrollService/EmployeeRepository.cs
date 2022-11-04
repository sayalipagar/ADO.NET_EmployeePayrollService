using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_PayrollService
{
    public class EmployeeRepository
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=EMP_PAYROLL_SERVICE;Integrated Security=True;";
        public static void GetAllEmployee()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string query = "Select * from EMPLOYEE_PAYROLL";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                EmployeePayroll model = new EmployeePayroll();
                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmployeeId = Convert.ToInt32(reader["Id"] == DBNull.Value ? default : reader["Id"]);
                            model.Name = reader["NAME"] == DBNull.Value ? default : reader["NAME"].ToString();
                            model.Salary = Convert.ToDouble(reader["Salary"] == DBNull.Value ? default : reader["Salary"]);
                            model.StartDate = (DateTime)((reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]));
                            model.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                            model.Address = reader["Emp_Address"] == DBNull.Value ? default : reader["Emp_Address"].ToString();
                            model.Department = reader["Emp_DEPT"] == DBNull.Value ? default : reader["Emp_DEPT"].ToString();
                            model.BasicPay = Convert.ToDouble(reader["Basic_Pay"] == DBNull.Value ? default : reader["Basic_Pay"]);
                            model.Deduction = Convert.ToDouble(reader["Deduction"] == DBNull.Value ? default : reader["Deduction"]);
                            model.TaxablePay = Convert.ToDouble(reader["Taxable_Pay"] == DBNull.Value ? default : reader["Taxable_Pay"]);
                            model.IncomeTax = Convert.ToDouble(reader["Income_Tax"] == DBNull.Value ? default : reader["Income_Tax"]);
                            model.NetPay = Convert.ToDouble(reader["Net_Pay"] == DBNull.Value ? default : reader["Net_Pay"]);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", model.EmployeeId, model.Name, model.BasicPay, model.Salary, model.StartDate, model.Gender, model.Department, model.Address, model.TaxablePay, model.IncomeTax, model.NetPay, model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


}

