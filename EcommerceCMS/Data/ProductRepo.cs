using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EcommerceCMS.Models;

namespace EcommerceCMS.Data
{
    public static class ProductRepo
    {
        public static List<ProductModel> GetProductsFromWebsiteCategory(int webId, int categoryId) {

            List<ProductModel> prods = new List<ProductModel>();
            EcommerceCMSEntities db = new EcommerceCMSEntities();

            //get website connection info
            List<Website> webs = new List<Website>();

            if (webId > 0)
            {
                webs.Add(db.Websites.SingleOrDefault(w => w.Id == webId));
            }
            else
            {
                webs = db.Websites.ToList();
            }

            foreach (Website web in webs)
            {
                string connStr = string.Format("server={0};database={1};uid={2};pwd={3};", web.ServerName, web.DatabaseName, web.Username, web.Password);

                //get products
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand comm = new SqlCommand(string.Format("select p.id, p.sku, p.name, p.shortdescription, p.price, p.productcost, logo = '{0}/content/images/thumbs/' + RIGHT('0000000' + CAST(p1.Id AS VARCHAR(7)), 7) + '_' + p1.seofilename + '.jpeg' from product p inner join Product_Category_Mapping pcm on pcm.productid = p.id inner join category c on c.id = pcm.categoryid inner join product_picture_mapping ppm on ppm.pictureid = p.id inner join picture p1 on p1.id = ppm.productid where c.id = {1}", web.Url, categoryId), conn);
                    SqlDataReader reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        prods.Add(new ProductModel()
                        {
                            Id = int.Parse(reader["id"].ToString()),
                            Sku = reader["sku"].ToString(),
                            Name = reader["name"].ToString(),
                            Description = reader["shortdescription"].ToString(),
                            ImgUrl = reader["logo"].ToString(),
                            Wholesale = decimal.Parse(reader["productcost"].ToString()),
                            Retail = decimal.Parse(reader["price"].ToString())
                        });
                    }
                }

            }

            return prods;
        }

        public static List<ProductModel> GetProductsFromSupplierCategory(int supplierId, int categoryId)
        {

            List<ProductModel> list = new List<ProductModel>();

            list.Add(new ProductModel() { Id = 11, Name = "Product 11", ImgUrl = "http://toysandgamesroom.com/content/images/thumbs/0000036_Contixo-RC-Helicopter-Drone-24Ghz-6-Axis-Gyro-4-Channels-w720p-HD-Camera-FPV-Live-Feed_550.jpeg" });
            list.Add(new ProductModel() { Id = 22, Name = "Product 22", ImgUrl = "http://toysandgamesroom.com/content/images/thumbs/0000036_Contixo-RC-Helicopter-Drone-24Ghz-6-Axis-Gyro-4-Channels-w720p-HD-Camera-FPV-Live-Feed_550.jpeg" });
            list.Add(new ProductModel() { Id = 33, Name = "Product 33", ImgUrl = "http://toysandgamesroom.com/content/images/thumbs/0000036_Contixo-RC-Helicopter-Drone-24Ghz-6-Axis-Gyro-4-Channels-w720p-HD-Camera-FPV-Live-Feed_550.jpeg" });
            list.Add(new ProductModel() { Id = 44, Name = "Product 44", ImgUrl = "http://toysandgamesroom.com/content/images/thumbs/0000036_Contixo-RC-Helicopter-Drone-24Ghz-6-Axis-Gyro-4-Channels-w720p-HD-Camera-FPV-Live-Feed_550.jpeg" });
            list.Add(new ProductModel() { Id = 55, Name = "Product 55", ImgUrl = "http://toysandgamesroom.com/content/images/thumbs/0000036_Contixo-RC-Helicopter-Drone-24Ghz-6-Axis-Gyro-4-Channels-w720p-HD-Camera-FPV-Live-Feed_550.jpeg" });
            list.Add(new ProductModel() { Id = 66, Name = "Product 66", ImgUrl = "http://toysandgamesroom.com/content/images/thumbs/0000036_Contixo-RC-Helicopter-Drone-24Ghz-6-Axis-Gyro-4-Channels-w720p-HD-Camera-FPV-Live-Feed_550.jpeg" });

            return list;
        }
    }
}