using Shaurya_Round;
using Shaurya_Round.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Shaurya_Round.Data
{
    public class employeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public employeeDAL()
        {
            con = new SqlConnection(Startup.ConnectionStrings);
        }
        public List<employeee> Getemployee()
        {
            List<employeee> elist = new List<employeee>();

            string qry = "select * from employeee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employeee emp = new employeee();
                    emp.Eid = Convert.ToInt32(dr["Eid"]);
                    emp.Fname = dr["Fname"].ToString();
                    emp.Mname = dr["Mname"].ToString();
                    emp.Lname = dr["Lname"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.DOB = dr["DOB"].ToString();
                    emp.Address = dr["Address"].ToString();
                    emp.City = dr["City"].ToString();
                    emp.Pcode = Convert.ToInt32(dr["Pcode"]);
                    emp.Mobile = Convert.ToString(dr["Mobile"]);
                    elist.Add(emp);
                }
            }
            con.Close();
            return elist;
        }
        public employeee GetemployeebyId(int id)
        {
            employeee emp = new employeee();
            string qry = "select * from employeee where Eid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Eid = Convert.ToInt32(dr["Eid"]);
                    emp.Fname = dr["Fname"].ToString();
                    emp.Mname = dr["Mname"].ToString();
                    emp.Lname = dr["Lname"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.DOB = dr["DOB"].ToString();
                    emp.Address = dr["Address"].ToString();
                    emp.City = dr["City"].ToString();
                    emp.Pcode = Convert.ToInt32(dr["Pcode"]);
                    emp.Mobile = Convert.ToString(dr["Mobile"]);

                }
            }
            con.Close();
            return emp;
        }
        public int Addemployee(employeee emp)
        {
            string qry = "insert into employeee values(@fname,@mname,@lname,@gender,@dob,@address,@city,@pcode,@mobile)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@fname", emp.Fname);
            cmd.Parameters.AddWithValue("@mname", emp.Mname);
            cmd.Parameters.AddWithValue("@lname", emp.Lname);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            cmd.Parameters.AddWithValue("@dob", emp.DOB);
            cmd.Parameters.AddWithValue("@address", emp.Address);
            cmd.Parameters.AddWithValue("@city", emp.City);
            cmd.Parameters.AddWithValue("@pcode", emp.Pcode);
            cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int Updateemployee(employeee emp)
        {
            string qry = "update employeee set  Fname=@fname,Mname=@mname,Lname=@lname,Gender=@gender,DOB=@dob,Address=@address,City=@city,Pcode=@pcode,Mobile=@mobile where Eid=@id";
            DateTime date = Convert.ToDateTime(emp.DOB);
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", emp.Eid);
            cmd.Parameters.AddWithValue("@fname", emp.Fname);
            cmd.Parameters.AddWithValue("@mname", emp.Mname);
            cmd.Parameters.AddWithValue("@lname", emp.Lname);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            cmd.Parameters.AddWithValue("@dob", date.Date);
            cmd.Parameters.AddWithValue("@address", emp.Address);
            cmd.Parameters.AddWithValue("@city", emp.City);
            cmd.Parameters.AddWithValue("@pcode", emp.Pcode);
            cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int Deleteemployee(int id)
        {
            string qry = "delete from employeee where Eid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
    }
}