using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agjensi_udhetimi
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPaketat();
            }
        }

        private void LoadPaketat()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM paketat", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                rptPaketat.DataSource = reader;
                rptPaketat.DataBind();
            }
        }
    }
}
