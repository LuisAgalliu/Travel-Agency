using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agjensi_udhetimi
{
    public partial class menaxhim_paketash : System.Web.UI.Page
    {
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kontrollo nëse përdoruesi është admin
                if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                // Shfaq mesazhin e suksesit nëse ekziston
                if (!string.IsNullOrEmpty(Request.QueryString["success"]))
                {
                    lblMessage.Text = Server.HtmlEncode(Request.QueryString["success"]);
                    lblMessage.CssClass = "success";
                    lblMessage.Visible = true;
                }

                // Ngarko paketat
                LoadPaketat();
            }
        }

        private void LoadPaketat()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM paketat ORDER BY paketa_id ASC", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvPaketat.DataSource = dt;
                    gvPaketat.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error gjatë ngarkimit të paketave: " + Server.HtmlEncode(ex.Message);
                lblMessage.CssClass = "error";
                lblMessage.Visible = true;
            }
        }

        protected void btnAddPaketa_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string destinacion = txtDestinacion.Text.Trim();
            string cmimText = txtCmim.Text.Trim();
            string pershkrimi = txtPershkrimi.Text.Trim();
            string image = txtImage.Text.Trim();

            // Valido fushat
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(destinacion) || string.IsNullOrEmpty(cmimText) || string.IsNullOrEmpty(pershkrimi) || string.IsNullOrEmpty(image))
            {
                lblMessage.Text = "Plotësoni të gjitha fushat e kërkuara.";
                lblMessage.CssClass = "error";
                lblMessage.Visible = true;
                return;
            }

            if (!decimal.TryParse(cmimText, out decimal cmim))
            {
                lblMessage.Text = "Çmimi duhet të jetë një numër i vlefshëm.";
                lblMessage.CssClass = "error";
                lblMessage.Visible = true;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO paketat (title, destinacion, cmim, pershkrimi, image) VALUES (@title, @destinacion, @cmim, @pershkrimi, @image)", conn);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@destinacion", destinacion);
                    cmd.Parameters.AddWithValue("@cmim", cmim);
                    cmd.Parameters.AddWithValue("@pershkrimi", pershkrimi);
                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.ExecuteNonQuery();
                }

                Response.Redirect("menaxhim_paketash.aspx?success=Paketa u shtua me sukses!!");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error gjatë shtimit të paketës: " + Server.HtmlEncode(ex.Message);
                lblMessage.CssClass = "error";
                lblMessage.Visible = true;
            }
        }

        protected void gvPaketat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int paketaId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeletePaketa")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM paketat WHERE paketa_id = @paketa_id", conn);
                        cmd.Parameters.AddWithValue("@paketa_id", paketaId);
                        cmd.ExecuteNonQuery();
                    }

                    Response.Redirect("menaxhim_paketash.aspx?success=Paketa u fshi me sukses!!");
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error gjatë fshirjes së paketës: " + Server.HtmlEncode(ex.Message);
                    lblMessage.CssClass = "error";
                    lblMessage.Visible = true;
                }
            }
            else if (e.CommandName == "EditPaketa")
            {
                Response.Redirect($"edit_paketen.aspx?id={paketaId}");
            }
        }
    }
}