using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agjensi_udhetimi
{
    public partial class Konfirmim_Rezervimi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifiko nëse user_id dhe paketa_id janë të pranishëm në query string
                if (Request.QueryString["user_id"] == null || Request.QueryString["paketa_id"] == null)
                {
                    Response.Redirect("index.aspx");
                    return;
                }

                int userId, paketaId;
                if (!int.TryParse(Request.QueryString["user_id"], out userId) || !int.TryParse(Request.QueryString["paketa_id"], out paketaId))
                {
                    Response.Redirect("index.aspx");
                    return;
                }

                // Opsionale: Mund të shtosh logjikë për të verifikuar rezervimin në bazën e të dhënave
                // Për shembull, kontrollo nëse ekziston një rezervim me këto user_id dhe paketa_id
            }
        }
    }
}