using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agjensi_udhetimi
{
    public partial class admin : System.Web.UI.Page
    {
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

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
                LoadDashboardData();
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Numri i paketave
                    SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM paketat", conn);
                    lblPaketat.Text = cmd1.ExecuteScalar().ToString();

                    // Numri i përdoruesve (vetëm ata me rolin 'user')
                    SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM users WHERE role = 'user'", conn);
                    lblUsers.Text = cmd2.ExecuteScalar().ToString();

                    // Numri i rezervimeve (korrigjo emrin e tabelës nga 'rezervim' në 'rezervimet')
                    SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM rezervim", conn);
                    lblRezervimet.Text = cmd3.ExecuteScalar().ToString();

                    // Rezervimet e fundit
                    SqlCommand cmd4 = new SqlCommand(@"
                        SELECT TOP 5 r.data_rezervim, u.username, p.title, p.destinacion
                        FROM rezervim r
                        JOIN users u ON r.user_id = u.id
                        JOIN paketat p ON r.paketa_id = p.paketa_id
                        ORDER BY r.data_rezervim DESC", conn);

                    SqlDataReader reader = cmd4.ExecuteReader();
                    while (reader.Read())
                    {
                        string li = $"{reader["username"]} rezervoi Paketën Turistike në {reader["destinacion"]} në {Convert.ToDateTime(reader["data_rezervim"]).ToString("dd/MM/yyyy")}";
                        lstRecentBookings.Items.Add(li);
                    }
                }
            }
            catch (Exception ex)
            {
                // Shfaq një mesazh gabimi nëse ndodh një problem gjatë ngarkimit të të dhënave
                Response.Write($"Error gjatë ngarkimit të të dhënave të dashboard-it: {Server.HtmlEncode(ex.Message)}");
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            // Pastro sesionin
            Session.Clear(); // Fshin të gjitha variablat e sesionit
            Session.Abandon(); // Përfundon sesionin aktual
            Session.RemoveAll(); // Sigurohet që të gjitha çelësat e sesionit të hiqen

            // Rridrejto në index.aspx
            Response.Redirect("index.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}
