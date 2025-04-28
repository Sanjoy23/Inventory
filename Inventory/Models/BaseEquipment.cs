using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
	public class BaseEquipment
	{
		public int EquipmentID { get; set; }
		public string EquipName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public DateTime EntryDate { get; set; }
		public DateTime ReceivedDate { get; set; }
		public int Stock { get; set; }

		public List<BaseEquipment> ListEquipment()
		{
			List<BaseEquipment> listEquipment = new List<BaseEquipment>();
			string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

			SqlConnection sqlConnection = new SqlConnection(connString);
			sqlConnection.Open();

			string CommandText = "spOST_LstEquipment";
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
					BaseEquipment objEquipment = new BaseEquipment();
					objEquipment.EquipmentID = Convert.ToInt32(reader["EquipmentId"].ToString());
					objEquipment.EquipName = reader["EquipName"].ToString();
					objEquipment.Quantity = Convert.ToInt32(reader["Quantity"].ToString()); 
					objEquipment.UnitPrice = Convert.ToDecimal(reader["UnitPrice"].ToString()) ; 
					objEquipment.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString()); 
					objEquipment.ReceivedDate = Convert.ToDateTime(reader["ReceivedDate"].ToString()); 
					objEquipment.Stock = Convert.ToInt32(reader["Stock"].ToString()); 
					listEquipment.Add(objEquipment);
				}	
			}
			cmd.Dispose();
			sqlConnection.Close();
			return listEquipment;
		}

		public int SaveEquipment(string name, int quantity, int stock)
		{
			string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

			SqlConnection sqlConnection = new SqlConnection(connString);
			sqlConnection.Open();

			string CommandText = "spOST_InsertEquipment";
			SqlCommand cmd = new SqlCommand(CommandText, sqlConnection);
			
			cmd.CommandTimeout = 0;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@EquipName", name);
			cmd.Parameters.AddWithValue("@EquipQuantity", quantity);
			cmd.Parameters.AddWithValue("@EquipStock", stock);
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			sqlConnection.Close();
			return 1;
		}
	}
}