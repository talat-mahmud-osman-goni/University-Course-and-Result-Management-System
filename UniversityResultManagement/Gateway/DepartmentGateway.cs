using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Gateway
{
    public class DepartmentGateway:CommonGateway
    {
        public int SaveDepartment(Department aDepartment)
        {
            Query = "INSERT INTO Department VALUES ('" + aDepartment.Code + "','" + aDepartment.Name + "')";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public Department IsCodeUnique(string code)
        {
            Query = "SELECT * FROM Department WHERE Code='" + code + "'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Department aDepartment=new Department();
            if (!Reader.HasRows)
            {
                aDepartment = null;
            }
            Reader.Close();
            Connection.Close();
            return aDepartment;
        }
        public Department IsNameUnique(string name)
        {
            Query = "SELECT * FROM Department WHERE Name='" + name + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Department aDepartment = new Department();
            if (!Reader.HasRows)
            {
                aDepartment = null;
            }
            Reader.Close();
            Connection.Close();
            return aDepartment;
        }

        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department ORDER BY Code ASC";
            Command=new SqlCommand(Query,Connection);
            List<Department> aList=new List<Department>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department aDepartment = new Department()
                {
                    Id = (int) Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString()
                };
                aList.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }

        public List<SelectListItem> GetSelectDepartments()
        {
            Query = "SELECT * FROM Department";
            Command=new SqlCommand(Query,Connection);
            List<SelectListItem> aList=new List<SelectListItem>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                aList.Add(new SelectListItem()
                {
                    Value = Reader["Id"].ToString(),
                    Text = Reader["Code"].ToString()
                });
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }
    }
}