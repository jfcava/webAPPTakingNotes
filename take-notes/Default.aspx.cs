using backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace take_notes
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.activeSession(Session["user"]))
            {
                NoteBusiness business = new NoteBusiness();
                List<Note> noteList = business.list();
                Session.Add("noteList", noteList);

                CategoryBusiness categoryBusiness = new CategoryBusiness();

                if (!IsPostBack)
                {
                    repRepetidor.DataSource = noteList;
                    repRepetidor.DataBind();

                    ddlFilter.DataSource = categoryBusiness.list();
                    ddlFilter.DataTextField = "Description";
                    ddlFilter.DataValueField = "Id";
                    ddlFilter.DataBind();
                }
            }
            else
                Response.Redirect("Login.aspx", false);
        }

        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNote.aspx", false);
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((LinkButton)sender).CommandArgument);
            Response.Redirect("AddNote.aspx?id=" + id, false);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((LinkButton)sender).CommandArgument);
            NoteBusiness business = new NoteBusiness();

            try
            {
                business.delete(id);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((LinkButton)sender).CommandArgument);
            NoteBusiness business = new NoteBusiness();

            try
            {
                business.fileNote(id, true);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            List<Note> filteredList = ((List<Note>)Session["noteList"]).FindAll(x => x.Category.Description.Contains(ddlFilter.SelectedItem.Text));
            repRepetidor.DataSource = filteredList;
            repRepetidor.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            repRepetidor.DataSource = (List<Note>)Session["noteList"];
            repRepetidor.DataBind();
        }
    }
}