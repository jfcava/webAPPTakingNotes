using backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace take_notes
{
    public partial class Archived : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.activeSession(Session["user"]))
            {
                NoteBusiness business = new NoteBusiness();
                List<Note> archivedList = business.listArchived();

                if (!IsPostBack)
                {
                    repRepetidor.DataSource = archivedList;
                    repRepetidor.DataBind();
                }
            }
            else
                Response.Redirect("Login.aspx", false);
        }

        protected void btnUnfile_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((LinkButton)sender).CommandArgument);
            NoteBusiness business = new NoteBusiness();

            try
            {
                business.fileNote(id, false);
                Response.Redirect("Archived.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}