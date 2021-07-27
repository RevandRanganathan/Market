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
    public class SellerProductRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconnsdbContext"].ToString();
            con = new SqlConnection(constr);

        }

        public List<ViewModel> SellersProduct(int SellerId)
        {
            connection();
            List<ViewModel> SellersProduct = new List<ViewModel>();


            SqlCommand com = new SqlCommand("SellProduct", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerId", SellerId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                SellersProduct.Add(

                    new ViewModel
                    {
                        SellerProductId = Convert.ToInt32(dr["SellerProductId"]),
                        SellerId = Convert.ToInt32(dr["SellerId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToInt32(dr["Price"]),
                         Pkgd= Convert.ToDateTime(dr["Pkgd"]),
                        Exp = Convert.ToDateTime(dr["Exp"]),
                        Rating=Convert.ToInt32(dr["Rating"])

                    }
                    );
            }

            return SellersProduct;
        }

        public bool DeleteSellerProduct(int SellerProductId)
        {

            connection();
            SqlCommand com = new SqlCommand("DelProductFromSeller", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SellerProductId", SellerProductId);

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

        public bool AddSellersproduct(SellerProduct obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddSellerPro", con);
            com.CommandType = CommandType.StoredProcedure;
            //  com.Parameters.AddWithValue("@sid", obj.);
            com.Parameters.AddWithValue("@SellerId", obj.SellerId);
            com.Parameters.AddWithValue("@ProductId", obj.ProductId);


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

        

    }

}