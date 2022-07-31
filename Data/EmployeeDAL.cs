using Shaurya_Round.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Shaurya_Round.Data
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public EmployeeDAL()
        {
            con = new SqlConnection(Startup.ConnectionStrings);
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> elist = new List<Employee>();
            string qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee e = new Employee();
                    e.e_id = Convert.ToInt32(dr["e_id"]);
                    e.Fname= dr["Fname"].ToString();
                    e.Mname = dr["Mname"].ToString();
                    e.Lname = dr["Lname"].ToString();
                    e.Gender = dr["Gender"].ToString();
                    e.DOB = dr["DOB"].ToString();
                    e.Address = dr["Address"].ToString();
                    e.City = dr["City"].ToString();
                    e.Pincode = Convert.ToInt32(dr["Pincode"]);
                    e.MobileNo = Convert.ToInt32(dr["MobileNo"]);

                    elist.Add(e);
                }
            }
            con.Close();
            return elist;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee e = new Employee();
            string qry = "select * from Employee where e_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    e.e_id= Convert.ToInt32(dr["e_id"]);
                    e.Fname = dr["Fname"].ToString();
                    e.Mname = dr["Mname"].ToString();
                    e.Lname = dr["Lname"].ToString();
                    e.Gender = dr["Gender"].ToString();
                    e.DOB = dr["DOB"].ToString();
                    e.Address = dr["Address"].ToString();
                    e.City = dr["City"].ToString();
                    e.Pincode = Convert.ToInt32(dr["Pincode"]);
                    e.MobileNo = Convert.ToInt32(dr["MobileNo"]);
                }
            }
            con.Close();
            return e;
        }
        public int AddEmployee(Employee employee)
        {
            string qry = "insert into Employee values(@fname,@mname,@lname,@gender,@dob,@address,@city,@pincode,@mobileNo)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@fname", employee.Fname);
            cmd.Parameters.AddWithValue("@mname", employee.Mname);
            cmd.Parameters.AddWithValue("@lname", employee.Lname);
            cmd.Parameters.AddWithValue("@gender", employee.Gender);
            cmd.Parameters.AddWithValue("@dob", employee.DOB);
            cmd.Parameters.AddWithValue("@address", employee.Address);
            cmd.Parameters.AddWithValue("@city", employee.City);
            cmd.Parameters.AddWithValue("@pincode", employee.Pincode);
            cmd.Parameters.AddWithValue("@mobileNo", employee.MobileNo);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateEmployee(Employee employee)
        {
            string qry = "update Employee set Fname=@fname,Mname = @mname,Lname = @lname,Gender = @gender,DOB = @dob,Address = @address,City = @city,Pincode = @pincode,MobileNo = @mobileNo where e_id = @id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", employee.e_id);
            cmd.Parameters.AddWithValue("@fname", employee.Fname);
            cmd.Parameters.AddWithValue("@mname", employee.Mname);
            cmd.Parameters.AddWithValue("@lname", employee.Lname);
            cmd.Parameters.AddWithValue("@gender", employee.Gender);
            cmd.Parameters.AddWithValue("@dob", employee.DOB);
            cmd.Parameters.AddWithValue("@address", employee.Address);
            cmd.Parameters.AddWithValue("@city", employee.City);
            cmd.Parameters.AddWithValue("@pincode", employee.Pincode);
            cmd.Parameters.AddWithValue("@mobileNo", employee.MobileNo);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteEmployee(int id)
        {
            string qry = "delete from Employee where e_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}

