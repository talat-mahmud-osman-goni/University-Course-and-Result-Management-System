using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Gateway
{
    public class StudentGateway:CommonGateway
    {
        public int SaveStudent(Student aStudent)
        {
            aStudent.RegistrationNo = GetRegistrationNo(aStudent);
            Query = "INSERT INTO Students VALUES ('" + aStudent.Name + "','" + aStudent.Email + "','" +
                    aStudent.ContactNo + "','" + aStudent.Date + "','" + aStudent.Address + "','" +
                    aStudent.DepartmentId + "','"+aStudent.RegistrationNo+"')";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            // Showing Department Name in View
            Query = "SELECT Name FROM Department WHERE Id=" + aStudent.DepartmentId;
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                aStudent.DepartmentName = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return rowAffected;
        }
        public string GetRegistrationNo(Student aStudent)
        {
            string regNo = "";
            Query = "SELECT Code FROM Department WHERE Id=" + aStudent.DepartmentId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                regNo = Reader["Code"].ToString();
            }
            Reader.Close();
            Connection.Close();
            regNo += "-";
            regNo += aStudent.Date.Year;
            regNo += "-";
            string pattern = "%" + regNo + "%";
            Query = "SELECT COUNT(RegistrationNo) AS Total FROM Students WHERE RegistrationNo LIKE '" + pattern + "'";
            int total = 0;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                total = (int)Reader["Total"];
            }
            Reader.Close();
            Connection.Close();
            total++;
            string number = total.ToString();
            int diff = 3 - number.Length;
            for (int i = 1; i <= diff; i++)
            {
                number = "0" + number;
            }
            regNo += number;
            return regNo;
        }
        public Student IsEmailExists(string email)
        {
            Query = "SELECT * FROM Students WHERE Email='" + email + "'";
            Command = new SqlCommand(Query, Connection);
            Student aStudent = new Student();
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (!Reader.HasRows)
            {
                aStudent = null;
            }
            Reader.Close();
            Connection.Close();
            return aStudent;
        }

        
        public List<SelectListItem> GetSelectRegNo()
        {
            Query = "SELECT * FROM Students";
            Command = new SqlCommand(Query, Connection);
            List<SelectListItem> aList = new List<SelectListItem>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                aList.Add(new SelectListItem()
                {
                    Value = Reader["Id"].ToString(),
                    Text = Reader["RegistrationNo"].ToString()
                });
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }

        public List<Student> GetAllStudents(int studentId)
        {
            Query = "SELECT * FROM Students WHERE Id='" + studentId + "' ORDER BY RegistrationNo";
            Command=new SqlCommand(Query,Connection);
            List<Student> aList=new List<Student>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student aStudent = new Student()
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    Email = Reader["Email"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    Address = Reader["Address"].ToString(),
                    DepartmentId = (int) Reader["DepartmentId"]

                };
                aList.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            // For name of the Department
            foreach (Student t in aList)
            {               
                Query = "SELECT Name FROM Department WHERE Id=" + t.DepartmentId;
                Command=new SqlCommand(Query,Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    t.DepartmentName = Reader["Name"].ToString();
                }
                Reader.Close();
                Connection.Close();
            }
            return aList;
        }
    }
}