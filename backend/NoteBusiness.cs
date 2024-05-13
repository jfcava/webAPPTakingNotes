using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace backend
{
    public class NoteBusiness
    {
        public void add(Note newNote)
        {
            AccessDB data = new AccessDB();

            try
            {
                data.setQuery("insert into NOTAS values (@title,@description,@idCategory,0)");
                data.setParameters("@title", newNote.Title);
                data.setParameters("@description", newNote.Description);
                data.setParameters("@idCategory", newNote.Category.Id);

                data.executeWriting();

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

        public List<Note> list(string id = "")
        {
            AccessDB data = new AccessDB();
            List<Note> list = new List<Note>();

            try
            {
                string query = "SELECT N.Id, Title, N.Description, C.Description Category, N.IdCategory FROM NOTAS N, CATEGORIES C WHERE N.IdCategory = C.Id AND Archived=0";

                if (id != "")
                {
                    query += " And N.Id = " + id;
                }

                query += " ORDER BY n.id DESC";

                data.setQuery(query);
                data.executeReading();

                while (data.Reader.Read())
                {
                    Note aux = new Note();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Title = (string)data.Reader["Title"];
                    aux.Description = (string)data.Reader["Description"];
                    aux.Category = new Category();
                    aux.Category.Id = (int)data.Reader["IdCategory"];
                    aux.Category.Description = (string)data.Reader["Category"];

                    list.Add(aux);
                }
                return list;
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

        public void modify(Note newNote)
        {
            AccessDB data = new AccessDB();

            try
            {
                data.setQuery("UPDATE NOTAS SET title=@title,description=@description,idCategory=@idCategory WHERE id=@id");
                data.setParameters("@title", newNote.Title);
                data.setParameters("@description", newNote.Description);
                data.setParameters("@idCategory", newNote.Category.Id);
                data.setParameters("id", newNote.Id);

                data.executeWriting();

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

        public void delete(int id)
        {
            AccessDB data = new AccessDB();

            try
            {
                data.setQuery("DELETE FROM NOTAS WHERE id=@id");
                data.setParameters("@id", id);

                data.executeWriting();
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

        public List<Note> listArchived(string id = "")
        {
            AccessDB data = new AccessDB();
            List<Note> list = new List<Note>();

            try
            {
                string query = "SELECT N.Id, Title, N.Description, C.Description Category, N.IdCategory FROM NOTAS N, CATEGORIES C WHERE N.IdCategory = C.Id AND Archived=1";

                if (id != "")
                {
                    query += " And N.Id = " + id;
                }

                query += " ORDER BY n.id DESC";

                data.setQuery(query);
                data.executeReading();

                while (data.Reader.Read())
                {
                    Note aux = new Note();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Title = (string)data.Reader["Title"];
                    aux.Description = (string)data.Reader["Description"];
                    aux.Category = new Category();
                    aux.Category.Id = (int)data.Reader["IdCategory"];
                    aux.Category.Description = (string)data.Reader["Category"];

                    list.Add(aux);
                }
                return list;
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

        public void fileNote(int id, bool flag)
        {
            AccessDB data = new AccessDB();

            try
            {
                string query;
                
                if (flag)
                    query = "UPDATE NOTAS SET archived=1 where id = @id";
                else
                    query = "UPDATE NOTAS SET archived=0 where id = @id";

                data.setQuery(query);
                data.setParameters("@id", id);

                data.executeWriting();
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
