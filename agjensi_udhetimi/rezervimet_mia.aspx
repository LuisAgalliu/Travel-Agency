<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rezervimet_mia.aspx.cs" Inherits="agjensi_udhetimi.rezervimet_mia" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <title>Rezervimet e mia</title>
    <link rel="stylesheet" href="assets/css/style.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 1000px;
            margin: 50px auto;
            padding: 20px;
            background: white;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            color : #212fa8;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 10px;
            text-align: left;
        }

        th {
            background-color: #212fa8;
            color: white;
        }

        .no-bookings {
            text-align: center;
            color: #555;
            font-size: 1.2em;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div class="container">
            <h2>Rezervimet e mia</h2>
            <asp:GridView ID="GridViewRezervimet" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="title" HeaderText="Paketa" />
                    <asp:BoundField DataField="destinacion" HeaderText="Destinacioni" />
                    <asp:BoundField DataField="cmim" HeaderText="Çmimi" DataFormatString="${0:F2}" />
                    <asp:BoundField DataField="data_rezervim" HeaderText="Data Rezervimit" />
                </Columns>
            </asp:GridView>

            <asp:Panel ID="NoBookingsPanel" runat="server" Visible="false" CssClass="no-bookings">
                Ju nuk keni asnjë rezervim ende.
                <a href="index.aspx">Shfleto Paketat</a> për të rezervuar udhëtimin tuaj të ëndrrave!
            </asp:Panel>
        </div>
    </form>
</body>
</html>
