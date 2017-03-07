using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityResultManagement.Gateway
{
    public class SemesterGateway:CommonGateway
    {
        public List<SelectListItem> GetSelectSemester()
        {
            Query = "SELECT * FROM Semester ORDER BY Name ASC";
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
    }
}