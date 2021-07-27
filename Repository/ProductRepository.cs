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
    public class ProductRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconnsdbContext"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddProduct(Product obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddPro1", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Price", obj.Price);
            com.Parameters.AddWithValue("@Pkgd", obj.Pkgd);
            com.Parameters.AddWithValue("@Exp", obj.Exp);
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

        public List<Product> GetAllProducts()
        {
            connection();
            List<Product> ProList = new List<Product>();


            SqlCommand com = new SqlCommand("GetPro1", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind Promodel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                ProList.Add(

                    new Product
                    {

                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToInt32(dr["Price"]),
                        Pkgd = Convert.ToDateTime(dr["Pkgd"]),
                        Exp = Convert.ToDateTime(dr["Exp"]),
                        Rating = Convert.ToInt32(dr["Rating"])






                    }
                    );
            }

            return ProList;
        }


        public Product GetData(int? id)
        {
            Product Product = new Product();

            connection();
            {

                SqlCommand cmd = new SqlCommand("GetById1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Product.ProductId = Convert.ToInt32(sdr["ProductId"]);
                    Product.Name = Convert.ToString(sdr["Name"]);
                    Product.Price = Convert.ToInt32(sdr["Price"]);
                    Product.Pkgd = Convert.ToDateTime(sdr["Pkgd"]);
                    Product.Exp = Convert.ToDateTime(sdr["Exp"]);
                    Product.Rating = Convert.ToInt32(sdr["Rating"]);


                }
            }
            return Product;
        }

        //Update   
        public bool UpdateProduct(Product obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdatePro1", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", obj.ProductId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Price", obj.Price);
            com.Parameters.AddWithValue("@Pkgd", obj.Pkgd);
            com.Parameters.AddWithValue("@Exp", obj.Exp);
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
        public bool DeleteProduct(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeletePro1", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", Id);

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
