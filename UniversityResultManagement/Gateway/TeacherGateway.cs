using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Gateway
{
    public class TeacherGateway:CommonGateway
    {
        public List<SelectListItem> GetSelectDesignations()
        {
            Query = "SELECT * FROM Designation";
            Command=new SqlCommand(Query,Connection);
            List<SelectListItem> aList=new List<SelectListItem>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                aList.Add(new SelectListItem()
                {
                    Value = Reader["Id"].ToString(),
                    Text = Reader["Name"].ToString()
                });

            }
            Reader.Close();
            Connection.Close();
            return aList;
        }

        public int SaveTeacher(Teacher aTeacher)
        {
            Query = "INSERT INTO Teacher VALUES ('" + aTeacher.Name + "','" + aTeacher.Address + "','" + aTeacher.Email +
                    "','" + aTeacher.ContactNo + "','" + aTeacher.DesignationId + "','" + aTeacher.DepartmentId + "','" +
                    aTeacher.CreditTaken + "','" + aTeacher.CreditTaken + "')";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public Teacher IsEmailExist(string email)
        {
            Query = "SELECT * FROM Teacher WHERE Email='" + email + "'";
            Command=new SqlCommand(Query,Connection);
            Teacher aTeacher=new Teacher();
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (!Reader.HasRows)
            {
                aTeacher = null;
            }
            Reader.Close();
            Connection.Close();
            return aTeacher;
        }

        public List<Teacher> GetAllTeachers()
        {
            Query = "SELECT * FROM Teacher ORDER BY DepartmentId ASC";
            Command = new SqlCommand(Query, Connection);
            List<Teacher> aList = new List<Teacher>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher()
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    Address = Reader["Address"].ToString(),
                    Email = Reader["Email"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    DesignationId = (int) Reader["DesignationId"],
                    DepartmentId = (int) Reader["DepartmentId"],
                    CreditTaken = Convert.ToDouble( Reader["CreditTaken"]),
                    RemainingCredit = Convert.ToDouble( Reader["RemainingCredit"])


                };
                aList.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }
    }
}