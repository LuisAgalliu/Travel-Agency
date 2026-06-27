using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agjensi_udhetimi
{
    public partial class Kontrollo_rezervimet : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kontrollo nëse përdoruesi është admin
            if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["delete_id"]))
                {
                    DeleteRezervim(Convert.ToInt32(Request.QueryString["delete_id"]));
                }

                LoadRezervimet();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = txtSearch.Text.Trim();

                string query = @"SELECT r.rezervim_id, u.username, p.title, r.data_rezervimit 
                             FROM rezervimet r
                             JOIN users u ON r.user_id = u.id
                             JOIN paketat p ON r.paketa_id = p.paketa_id
                             WHERE u.username LIKE @search OR p.title LIKE @search OR CAST(r.data_rezervim AS NVARCHAR) LIKE @search";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                    conn.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    rezervimeRepeater.DataSource = dt;
                    rezervimeRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Gabim gjatë kërkimit: " + Server.HtmlEncode(ex.Message);
                lblMessage.CssClass = "error";
                lblMessage.Visible = true;
            }
        }

        private void LoadRezervimet()
        {
            try
            {
                string query = @"SELECT r.rezervim_id, u.username, p.title, r.data_rezervim 
                             FROM rezervim r
                             JOIN users u ON r.user_id = u.id
                             JOIN paketat p ON r.paketa_id = p.paketa_id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    rezervimeRepeater.DataSource = dt;
                    rezervimeRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Gabim gjatë ngarkimit të rezervimeve: " + Server.HtmlEncode(ex.Message);
                lblMessage.CssClass = "error";
                lblMessage.Visible = true;
            }
        }

        private void DeleteRezervim(int rezervimId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM rezervim WHERE rezervim_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", rezervimId);
                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();

                    if (affected > 0)
                    {
                        lblMessage.Text = "Rezervimi u fshi me sukses!";
                        lblMessage.CssClass = "success";
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "Rezervimi nuk u gjet.";
                        lblMessage.CssClass = "error";
                        lblMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Gabim gjatë fshirjes së rezervimit: " + Server.HtmlEncode(ex.Message);
                lblMessage.CssClass = "error";
                lblMessage.Visible = true;
            }
        }
    }
}