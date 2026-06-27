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
    public partial class edit_paketen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null || Session["role"] == null || Session["role"].ToString() != "admin")
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    lblMessage.Text = "Asnjë paketë nuk u zgjodh.";
                    lblMessage.CssClass = "error";
                    formPanel.Visible = false;
                    return;
                }

                int paketaId = Convert.ToInt32(Request.QueryString["id"]);
                LoadPaketa(paketaId);
            }
        }

        private void LoadPaketa(int paketaId)
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM paketat WHERE paketa_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", paketaId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtTitle.Text = reader["title"].ToString();
                    txtDestinacion.Text = reader["destinacion"].ToString();
                    txtCmim.Text = reader["cmim"].ToString();
                    txtPershkrimi.Text = reader["pershkrimi"].ToString();
                    txtImage.Text = reader["image"].ToString();
                }
                else
                {
                    lblMessage.Text = "Paketa nuk u gjet.";
                    lblMessage.CssClass = "error";
                    formPanel.Visible = false;
                }

                reader.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                lblMessage.Text = "Paketa nuk u identifikua.";
                lblMessage.CssClass = "error";
                return;
            }

            int paketaId = Convert.ToInt32(Request.QueryString["id"]);
            string title = txtTitle.Text.Trim();
            string destinacion = txtDestinacion.Text.Trim();
            string pershkrimi = txtPershkrimi.Text.Trim();
            string image = txtImage.Text.Trim();
            decimal cmim;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(destinacion)
                || string.IsNullOrWhiteSpace(pershkrimi) || string.IsNullOrWhiteSpace(image)
                || !Decimal.TryParse(txtCmim.Text, out cmim))
            {
                lblMessage.Text = "Të gjitha fushat janë të detyrueshme.";
                lblMessage.CssClass = "error";
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE paketat SET title = @title, destinacion = @destinacion, cmim = @cmim, pershkrimi = @pershkrimi, image = @image WHERE paketa_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@destinacion", destinacion);
                cmd.Parameters.AddWithValue("@cmim", cmim);
                cmd.Parameters.AddWithValue("@pershkrimi", pershkrimi);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@id", paketaId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Response.Redirect("menaxhim_paketash.aspx?success=Paketa u përditësua me sukses!");
                }
                else
                {
                    lblMessage.Text = "Ndodhi një gabim gjatë përditësimit.";
                    lblMessage.CssClass = "error";
                }
            }
        }
    }
}