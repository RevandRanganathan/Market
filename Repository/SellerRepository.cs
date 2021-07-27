using Market.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Market.Repository
{
    public class SellerRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconnsdbContext"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddSeller(Seller obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddSel1", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@MobileNumber", obj.MobileNumber);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@Rating", obj.Rating);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

        public List<Seller> GetAllSellers()
        {
            connection();
            List<Seller> SelList = new List<Seller>();


            SqlCommand com = new SqlCommand("GetSeller1", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind Promodel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                SelList.Add(

                    new Seller
                    {

                        SellerId = Convert.ToInt32(dr["SellerId"]),
                        Name = Convert.ToString(dr["Name"]),
                        MobileNumber = Convert.ToString(dr["MobileNumber"]),
                        Address = Convert.ToString(dr["Address"]),
                        Rating = Convert.ToInt32(dr["Rating"])






                    }
                    );
            }

            return SelList;
        }


        public Seller GetData(int? id)
        {
            Seller Seller = new Seller();

            connection();
            {

                SqlCommand cmd = new SqlCommand("GetById11", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SellerId", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Seller.SellerId = Convert.ToInt32(sdr["SellerId"]);
                    Seller.Name = Convert.ToString(sdr["Name"]);
                    Seller.MobileNumber = Convert.ToString(sdr["MobileNumber"]);
                    Seller.Address = Convert.ToString(sdr["Address"]);
                    Seller.Rating = Convert.ToInt32(sdr["Rating"]);


                }
            }
            return Seller;
        }

        //Update   
        public bool UpdateSeller(Seller obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateSel1", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerId", obj.SellerId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@MobileNumber", obj.MobileNumber);
            com.Parameters.AddWithValue("@Address", obj.Address);
            
            com.Parameters.AddWithValue("@Rating", obj.Rating);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete    
        public bool DeleteSeller(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteSel1", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public List<ViewModel> Map(int? id)
        {
            connection();
            List<ViewModel> Map = new List<ViewModel>();


            SqlCommand com = new SqlCommand("GetProductsSeller", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();    
            foreach (DataRow dr in dt.Rows)
            {

                Map.Add(

                    new ViewModel
                    {
                        
                        SellerProductId= Convert.ToInt32(dr["SellerProductId"]),

                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToInt32(dr["Price"]),
                        Pkgd = Convert.ToDateTime(dr["Pkgd"]),
                        Exp = Convert.ToDateTime(dr["Exp"]),
                        Rating = Convert.ToInt32(dr["Rating"])

                    }
                    );
            }

            return Map;
        }

    }
}