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
    public partial class Login : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializo gjendjen fillestare
                hdnFormState.Value = "login";
                formTitle.InnerText = "Identifikohu";
                lnkToggle.Text = "Nuk keni një llogari? Regjistrohuni këtu.";
                pnlLogin.Visible = true;
                pnlRegister.Visible = false;
            }
            else
            {
                // Ruaj gjendjen pas PostBack
                if (hdnFormState.Value == "register")
                {
                    pnlLogin.Visible = false;
                    pnlRegister.Visible = true;
                    formTitle.InnerText = "Regjistrohu";
                    lnkToggle.Text = "Ke një llogari? Hyr këtu.";
                }
                else
                {
                    pnlLogin.Visible = true;
                    pnlRegister.Visible = false;
                    formTitle.InnerText = "Identifikohu";
                    lnkToggle.Text = "Nuk keni një llogari? Regjistrohuni këtu.";
                }
            }
        }

        protected void lnkToggle_Click(object sender, EventArgs e)
        {
            if (hdnFormState.Value == "login")
            {
                hdnFormState.Value = "register";
                pnlLogin.Visible = false;
                pnlRegister.Visible = true;
                formTitle.InnerText = "Regjistrohu";
                lnkToggle.Text = "Ke një llogari? Hyr këtu.";
            }
            else
            {
                hdnFormState.Value = "login";
                pnlLogin.Visible = true;
                pnlRegister.Visible = false;
                formTitle.InnerText = "Indetifikohu";
                lnkToggle.Text = "Nuk keni një llogari? Regjistrohuni këtu.";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username = @username", conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string dbPassword = reader["password"].ToString();
                    string role = reader["role"].ToString();

                    if (txtPassword.Text == dbPassword)
                    {
                        Session["user_id"] = reader["id"].ToString();
                        Session["username"] = reader["username"].ToString();
                        Session["role"] = role;

                        // Vendos Session["IsAdmin"] bazuar në rolin e përdoruesit
                        Session["IsAdmin"] = (role == "admin");

                        if (role == "admin")
                            Response.Redirect("admin.aspx");
                        else
                            Response.Redirect("index.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Fjalëkalimi është i gabuar.";
                    }
                }
                else
                {
                    lblMessage.Text = "Përdoruesi nuk u gjet.";
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand checkUser = new SqlCommand("SELECT COUNT(*) FROM users WHERE username = @username", conn);
                checkUser.Parameters.AddWithValue("@username", txtRegUsername.Text.Trim());
                int userCount = (int)checkUser.ExecuteScalar();

                if (userCount > 0)
                {
                    lblMessage.Text = "Përdoruesi ekziston.";
                    return;
                }

                SqlCommand insert = new SqlCommand("INSERT INTO users (username, email, password, role) VALUES (@username, @email, @password, 'user')", conn);
                insert.Parameters.AddWithValue("@username", txtRegUsername.Text.Trim());
                insert.Parameters.AddWithValue("@email", txtRegEmail.Text.Trim());
                insert.Parameters.AddWithValue("@password", txtRegPassword.Text);
                insert.ExecuteNonQuery();

                lblMessage.CssClass = "success";
                lblMessage.Text = "Regjistrimi u krye me sukses! Tani mund të identifikoheni.";
                hdnFormState.Value = "login"; // Kthehu te forma e login pas regjistrimit
                formTitle.InnerText = "Indetifikohu";
                lnkToggle.Text = "Nuk keni një llogari? Regjistrohuni këtu.";
                pnlLogin.Visible = true;
                pnlRegister.Visible = false;

                // Vendos Session["IsAdmin"] për përdoruesin e ri (që është user, jo admin)
                Session["IsAdmin"] = false;
                Session["username"] = txtRegUsername.Text.Trim();
            }
        }
    }
}
