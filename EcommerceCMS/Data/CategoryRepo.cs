using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using EcommerceCMS.Models;

namespace EcommerceCMS.Data
{
    public static class CategoryRepo
    {
        public static List<CategoryModel> GetCategoriesFromWebsite(int webId, int parentCatId)
        {
            List<CategoryModel> cats = new List<CategoryModel>();
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

            foreach (Website web in webs) {
                string connStr = string.Format("server={0};database={1};uid={2};pwd={3};", web.ServerName, web.DatabaseName, web.Username, web.Password);

                //get categories
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand comm = new SqlCommand(string.Format("select c1.id, c1.name, subcount = (select count(*) from category c2 where c1.id = c2.parentcategoryid), subcats = Stuff((Select ' <span class=\"btn btn-sm btn-info spanMngProds2\" data-parlevel=\"2\" data-parid=\"' + cast(c1.id as nvarchar(10)) + '\" data-parname=\"' + c1.name + '\"  data-level=\"3\"  data-id=\"' + cast(c3.id as nvarchar(10)) + '\" data-name=\"' + c3.name + '\">' + lower(c3.name) + '</span>' from category c3 where c3.parentcategoryid = c1.id for XML PATH('')),1,1,''), logo = '{0}/content/images/thumbs/' + RIGHT('0000000'+CAST(p1.Id AS VARCHAR(7)),7) + '_' + p1.seofilename + '.jpeg', productCount = (select count(pcm1.id) from Product_Category_Mapping pcm1 where pcm1.categoryid = c1.id) from category c1 inner join Picture p1 on p1.id = c1.pictureId where c1.parentcategoryid = {1}", web.Url, parentCatId), conn);
                    SqlDataReader reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        cats.Add(new CategoryModel()
                        {
                            Id = int.Parse(reader["id"].ToString()),
                            Name = reader["name"].ToString(),
                            SubCount = int.Parse(reader["subcount"].ToString()),
                            SubCats = reader["subcats"].ToString().Replace("&lt;", "<").Replace("&gt;", ">"),
                            Logo = reader["logo"].ToString(),
                            ProductCount = int.Parse(reader["productCount"].ToString())
                        });
                    }
                }

            }

            return cats;
        }

        public static List<CategoryModel> GetCategoriesFromSupplier(int supplierId)
        {

            List<CategoryModel> list = new List<CategoryModel>();

            list.Add(new CategoryModel() { Id = 1, Name = "Category 1", SubCount = 101 });
            list.Add(new CategoryModel() { Id = 2, Name = "Category 2", SubCount = 101 });
            list.Add(new CategoryModel() { Id = 3, Name = "Category 3", SubCount = 101 });
            list.Add(new CategoryModel() { Id = 4, Name = "Category 4", SubCount = 101 });
            list.Add(new CategoryModel() { Id = 5, Name = "Category 5", SubCount = 101 });

            return list;
        }
    }
}