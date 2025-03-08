using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class BasicMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DataTable ValidateMemberAsDataTable(string UserName, string password)
        {
            DataTable dataTable = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            //string conStirngApp = ConfigurationManager.AppSettings["connStringApp"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            string CommandText = "select * from OSTMembers where name= '" + UserName + "' and Password = '"+password +"'";
            SqlCommand cmd = new SqlCommand(CommandText, sqlConnection);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();

            //table data
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            sqlConnection.Close();
            return dataTable;
        }

        public List<BasicMember> ValidateMemberAsList(string UserName, string password)
        {
            List<BasicMember> listMember = new List<BasicMember>();
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            //string conStirngApp = ConfigurationManager.AppSettings["connStringApp"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            string CommandText = "select * from OSTMembers";
            SqlCommand cmd = new SqlCommand(CommandText, sqlConnection);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();

            //table data
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    BasicMember member = new BasicMember();
                    member.Name = reader["Name"].ToString();
                    member.Password = reader["Password"].ToString();
                    listMember.Add(member);
                }
            }

            cmd.Dispose();
            sqlConnection.Close();
            return listMember;   
        }
    }
}