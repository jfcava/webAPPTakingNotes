using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend
{
    public class CategoryBusiness
    {
        public List<Category> list()
        {
            List<Category> categoryList = new List<Category>();
            AccessDB data = new AccessDB(); 

            try
            {
                data.setQuery("select Id, Description from CATEGORIES");
                data.executeReading();

                while (data.Reader.Read())
                {
                    Category aux = new Category();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Description = (string)data.Reader["Description"];

                    categoryList.Add(aux);
                }

                return categoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }

        }
    }
}
