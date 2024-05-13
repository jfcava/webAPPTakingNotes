using backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace take_notes
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserBusiness business = new UserBusiness();

            try
            {
                user.Name = txtName.Text;
                user.Pass = txtPassword.Text;

                if (business.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblError.Text = "Please check your login credentials";
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}