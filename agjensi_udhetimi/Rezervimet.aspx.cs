using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agjensi_udhetimi
{
    public partial class Rezervimet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user_id"] == null)
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                if (Request.QueryString["paketa_id"] == null)
                {
                    lblMesazh.Text = "Asnjë paketë nuk është zgjedhur.";
                    lblMesazh.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                int paketaId;
                if (!int.TryParse(Request.QueryString["paketa_id"], out paketaId))
                {
                    lblMesazh.Text = "Paketa ID jo e vlefshme.";
                    lblMesazh.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM paketat WHERE paketa_id = @paketa_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@paketa_id", paketaId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblTitulli.Text = reader["title"].ToString();
                        lblDestinacioni.Text = reader["destinacion"].ToString();
                        lblCmimi.Text = reader["cmim"].ToString();
                        lblPershkrimi.Text = reader["pershkrimi"].ToString();
                        imgPaketa.ImageUrl = "assets/images/" + reader["image"].ToString();
                        ViewState["paketa_id"] = paketaId;
                    }
                    else
                    {
                        lblMesazh.Text = "Paketa nuk u gjend.";
                        lblMesazh.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void btnKonfirmo_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) // Sigurohu që validimi kalon
            {
                return;
            }

            if (Session["user_id"] == null || ViewState["paketa_id"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            int userId = Convert.ToInt32(Session["user_id"]);
            int paketaId = Convert.ToInt32(ViewState["paketa_id"]);
            string emriKartes = txtEmriKartes.Text.Trim();
            string numriKartes = txtNumriKartes.Text.Trim();

            // Validim shtesë për numrin e kartës
            if (numriKartes.Length != 16 || !numriKartes.All(char.IsDigit))
            {
                lblMesazh.Text = "Numri i kartës duhet të jetë 16 shifra!";
                lblMesazh.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO rezervim (user_id, paketa_id, emri_kartes, numri_kartes, data_rezervim) VALUES (@user_id, @paketa_id, @emri_kartes, @numri_kartes, @data)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@paketa_id", paketaId);
                    cmd.Parameters.AddWithValue("@emri_kartes", emriKartes);
                    cmd.Parameters.AddWithValue("@numri_kartes", numriKartes);
                    cmd.Parameters.AddWithValue("@data", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    // Ridrejtim në faqen e konfirmimit
                    Response.Redirect($"Konfirmim_Rezervimi.aspx?paketa_id={paketaId}&user_id={userId}");
                }
            }
            catch (Exception ex)
            {
                lblMesazh.Text = "Gabim gjatë rezervimit: " + ex.Message;
                lblMesazh.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}