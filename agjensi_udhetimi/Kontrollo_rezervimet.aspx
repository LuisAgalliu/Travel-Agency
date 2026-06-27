<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="Kontrollo_rezervimet.aspx.cs" Inherits="agjensi_udhetimi.Kontrollo_rezervimet" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="headTitle" runat="server">
    Shiko Rezervimet - Elite Travel Agency
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            background-color: #fff;
            color: #333;
            max-width: 1200px;
            margin: auto;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .success, .error {
            text-align: center;
            padding: 10px;
            margin: 10px 0;
            border-radius: 5px;
        }

        .success {
            background-color: #d4edda;
            color: #155724;
        }

        .error {
            background-color: #f8d7da;
            color: #721c24;
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
            text-align: left;
            padding: 8px;
        }

        th {
            background-color: #042f5c;
            color: white;
        }

        .actions a {
            text-decoration: none;
            color: white;
            background-color: #dc3545;
            padding: 5px 10px;
            border-radius: 5px;
        }

        .actions a:hover {
            background-color: #c82333;
        }

        .search-form {
            text-align: center;
            margin-bottom: 20px;
        }

        .search-box {
            padding: 10px;
            width: 300px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

        .search-button {
            padding: 10px 20px;
            background-color: #042f5c;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .search-button:hover {
            background-color: rgb(5, 113, 230);
        }

        h1 {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Shiko Rezervimet</h1>

        <asp:Label ID="lblMessage" runat="server" CssClass="success" Visible="false"></asp:Label>

        <div class="search-form">
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Kërko sipas emrit të përdoruesit, paketës ose datës." CssClass="search-box"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Kërko" OnClick="btnSearch_Click" CssClass="search-button" />
        </div>

        <asp:Repeater ID="rezervimeRepeater" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Rezervimi ID</th>
                            <th>Emri</th>
                            <th>Emri Paketës</th>
                            <th>Data Rezervimit</th>
                            <th>Veprimet</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("rezervim_id") %></td>
                    <td><%# Eval("username") %></td>
                    <td><%# Eval("title") %></td>
                    <td><%# Eval("data_rezervim") %></td>
                    <td class="actions">
                        <a href='Kontrollo_rezervimet.aspx?delete_id=<%# Eval("rezervim_id") %>' onclick="return confirm('A jeni i sigurt që dëshironi të fshini këtë rezervim?');">Fshi</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
