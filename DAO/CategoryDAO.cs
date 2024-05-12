using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungNguyenCoffee.DTO;

namespace TrungNguyenCoffee.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }
        public List<Category> LoadMenuWithCategories()
        {
            List<Category> categories = new List<Category>();

            // Sử dụng DataProvider để thực hiện truy vấn và lấy kết quả dưới dạng DataTable
            DataTable categoryTable = DataProvider.Instance.ExecuteQuery("USP_USP_GetCategories");

            foreach (DataRow categoryRow in categoryTable.Rows)
            {
                Category category = new Category(categoryRow); // Giả sử có lớp Category

                categories.Add(category);
            }

            return categories;
        }

        public void InsertCategory(string name)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertCategory @name", new object[] { name });
        }

        public List<Category> Searchcatebyname(string name)
        {
            List<Category> categories = new List<Category>();
            string query = string.Format("SELECT * FROM DBO.category WHERE name like N'%{0}%'", name);
            DataTable categoryTable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow categoryRow in categoryTable.Rows)
            {
                Category category = new Category(categoryRow); // Giả sử có lớp Category
                
                categories.Add(category);
            }

            return categories;
        }

        public void DeleteCategory(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteCategory @cateid", new object[] { id });

        }

        public void UpdateCategory(int id, string name)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateCategory @cateid , @name", new object[] { id, name });

        }
    }
}
