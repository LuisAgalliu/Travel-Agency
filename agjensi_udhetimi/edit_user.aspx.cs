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
    public partial class edit_user : System.Web.UI.Page
    {
        protected int UserId;
        private string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kontrollo nëse përdoruesi është admin
            if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // Kontrollo nëse ID-ja e përdoruesit është dhënë
            if (!int.TryParse(Request.QueryString["id"], out UserId))
            {
                MessageLiteral.Text = "<div class='error'>Asnjë përdorues nuk u zgjodh.</div>";
                return;
            }

            if (!IsPostBack)
            {
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM users WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", UserId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UsernameTextBox.Text = reader["username"].ToString();
                        EmailTextBox.Text = reader["email"].ToString();
                        RoleDropDown.SelectedValue = reader["role"].ToString();
                    }
                    else
                    {
                        MessageLiteral.Text = "<div class='error'>Përdoruesi nuk u gjet.</div>";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageLiteral.Text = $"<div class='error'>Gabim gjatë ngarkimit të të dhënave të përdoruesit: {Server.HtmlEncode(ex.Message)}</div>";
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UsernameTextBox.Text.Trim();
                string email = EmailTextBox.Text.Trim();
                string role = RoleDropDown.SelectedValue;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
                {
                    MessageLiteral.Text = "<div class='error'>Të gjitha fushat janë të detyrueshme.</div>";
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string updateQuery = "UPDATE users SET username = @username, email = @email, role = @role WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@id", UserId);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Response.Redirect("menaxhim_users.aspx?success=Përdoruesi u përditësua me sukses!");
                    }
                    else
                    {
                        MessageLiteral.Text = "<div class='error'>Përdoruesi nuk u gjet.</div>";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageLiteral.Text = $"<div class='error'>Gabim gjatë përditësimit të përdoruesit: {Server.HtmlEncode(ex.Message)}</div>";
            }
        }
    }
}