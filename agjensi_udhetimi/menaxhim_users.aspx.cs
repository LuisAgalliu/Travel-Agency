using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace agjensi_udhetimi
{
    public partial class menaxhim_users : System.Web.UI.Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

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
                LoadUsers();
            }
        }

        private void LoadUsers(string search = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT * FROM users";
                    if (!string.IsNullOrEmpty(search))
                    {
                        query += " WHERE username LIKE @search OR email LIKE @search OR role LIKE @search";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(search))
                        {
                            cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            gridUsers.DataSource = dt;
                            gridUsers.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                litError.Text = $"<div class='error'>Gabim gjatë ngarkimit të përdoruesve: {Server.HtmlEncode(ex.Message)}</div>";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            LoadUsers(searchTerm);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                int userId = Convert.ToInt32(btn.CommandArgument);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    // Kontrollo nëse përdoruesi është admin
                    SqlCommand checkCmd = new SqlCommand("SELECT role FROM users WHERE id = @id", conn);
                    checkCmd.Parameters.AddWithValue("@id", userId);
                    conn.Open();
                    string role = (string)checkCmd.ExecuteScalar();
                    conn.Close();

                    if (role == "admin")
                    {
                        litError.Text = "<div class='error'>Nuk mund të fshini një përdorues admin!</div>";
                        return;
                    }

                    // Fshi përdoruesin nëse nuk është admin
                    SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", userId);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (result > 0)
                    {
                        litSuccess.Text = "<div class='success'>Përdoruesi u fshi me sukses!</div>";
                    }
                    else
                    {
                        litError.Text = "<div class='error'>Përdoruesi nuk u gjet.</div>";
                    }
                }
            }
            catch (Exception ex)
            {
                litError.Text = $"<div class='error'>Gabim gjatë fshirjes së përdoruesit: {Server.HtmlEncode(ex.Message)}</div>";
            }

            LoadUsers();
        }
    }
}
