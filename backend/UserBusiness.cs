using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend
{
    public class UserBusiness
    {
        public bool Login(User user)
        {
            AccessDB data = new AccessDB();

            try
            {
                data.setQuery("SELECT id, name, pass FROM USERS WHERE name=@name AND pass=@pass");
                data.setParameters("@name", user.Name);
                data.setParameters("@pass", user.Pass);
                data.executeReading();

                if (data.Reader.Read())
                {
                    user.Id = (int)data.Reader["id"];
                    user.Name = (string)data.Reader["name"];
                    user.Pass = (string)data.Reader["pass"];
                    
                    //if (!(data.Reader["nombre"] is DBNull))
                    //    user.Name = (string)data.Reader["name"];
                    //if (!(data.Lector["apellido"] is DBNull))
                    //    user.Apellido = (string)datos.Lector["apellido"];
                    //if (!(data.Lector["urlImagenPerfil"] is DBNull))
                    //    user.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];

                    return true;
                }
                else
                    return false;
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
