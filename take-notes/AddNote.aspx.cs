using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using backend;

namespace take_notes
{
    public partial class AddNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.activeSession(Session["user"]))
            {
                if (!IsPostBack)
                {
                    CategoryBusiness categoryBusiness = new CategoryBusiness();

                    ddlCategory.DataSource = categoryBusiness.list();
                    ddlCategory.DataTextField = "Description";
                    ddlCategory.DataValueField = "Id";
                    ddlCategory.DataBind();
                }

                if (Request.QueryString["id"] != null && !IsPostBack)
                {
                    string id = Request.QueryString["id"].ToString();
                    NoteBusiness business = new NoteBusiness();
                    List<Note> modifiedList = business.list(id);

                    Note modified = modifiedList[0];

                    txtTitle.Text = modified.Title;
                    txtDescription.Text = modified.Description;

                    ddlCategory.SelectedValue = modified.Category.Id.ToString();
                }
            }
            else
                Response.Redirect("Login.aspx", false);
        }

        protected void btnAddNewNote_Click(object sender, EventArgs e)
        {
            try
            {
                Note newNote = new Note();
                NoteBusiness business = new NoteBusiness();

                newNote.Title = txtTitle.Text;

                newNote.Category = new Category();
                newNote.Category.Id = int.Parse(ddlCategory.SelectedValue);

                newNote.Description = txtDescription.Text;


                if (Request.QueryString["id"] == null)
                    business.add(newNote);
                else
                {
                    newNote.Id = int.Parse(Request.QueryString["id"]);
                    business.modify(newNote);
                }


                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}