using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agjensi_udhetimi
{
    public partial class rezervimet_mia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadRezervimet();
            }
        }

        private void LoadRezervimet()
        {
            int userId = Convert.ToInt32(Session["user_id"]);
            string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"SELECT p.title, p.destinacion, p.cmim, r.data_rezervim 
                             FROM rezervim r 
                             JOIN paketat p ON r.paketa_id = p.paketa_id 
                             WHERE r.user_id = @UserId 
                             ORDER BY r.data_rezervim DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        GridViewRezervimet.DataSource = reader;
                        GridViewRezervimet.DataBind();
                        NoBookingsPanel.Visible = false;
                    }
                    else
                    {
                        GridViewRezervimet.Visible = false;
                        NoBookingsPanel.Visible = true;
                    }
                }
            }
        }
    }
}