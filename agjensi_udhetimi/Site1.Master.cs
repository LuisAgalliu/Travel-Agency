using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agjensi_udhetimi
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kontrollo nëse përdoruesi është admin
            bool isAdmin = Session["IsAdmin"] != null && (bool)Session["IsAdmin"];

            // Shfaq header-in e duhur bazuar në statusin e përdoruesit
            phAdminHeader.Visible = isAdmin;
            phRegularHeader.Visible = !isAdmin;

            // Nëse përdoruesi nuk është admin dhe po përpiqet të hyjë në një faqe admin, ridrejto në Login.aspx
            string currentPage = System.IO.Path.GetFileNameWithoutExtension(Request.Path).ToLower();
            if (!isAdmin && (currentPage == "menaxhim_paketash" || currentPage == "admin" || currentPage == "kontrollo_rezervimet" || currentPage == "menaxhim_users"))
            {
                Response.Redirect("Login.aspx");
            }

            // Fshih footer-in për të gjitha faqet kur përdoruesi është admin
            if (isAdmin)
            {
                phFooter.Visible = false;
                System.Diagnostics.Debug.WriteLine("Footer hidden for admin user");
            }
            else
            {
                phFooter.Visible = true;
                System.Diagnostics.Debug.WriteLine("Footer visible for non-admin user");
            }

            // Vendos emrin e përdoruesit në header-in e adminit (nëse është admin)
            if (isAdmin && litUsername != null)
            {
                if (Session["username"] != null)
                {
                    litUsername.Text = Session["username"].ToString();
                }
                else
                {
                    litUsername.Text = "I panjohur";
                }
            }
        }
    }

}