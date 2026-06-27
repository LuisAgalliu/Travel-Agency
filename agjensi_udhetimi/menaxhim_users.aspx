<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="menaxhim_users.aspx.cs" Inherits="agjensi_udhetimi.menaxhim_users" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="headTitle" runat="server">
    Menaxho Përdoruesit - Elite Travel Agency
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

        .search-form input {
            padding: 10px;
            width: 300px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

        .search-form button {
            padding: 10px 20px;
            background-color: #042f5c;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .search-form button:hover {
            background-color: #0056b3;
        }

        h1 {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Menaxho Përdoruesit</h1>

        <asp:Literal ID="litSuccess" runat="server" />
        <asp:Literal ID="litError" runat="server" />

        <div class="search-form">
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Kërko sipas emrit të përdoruesit, email-it ose rolit" CssClass="search-box" />
            <asp:Button ID="btnSearch" runat="server" Text="Kërko" CssClass="search-button" OnClick="btnSearch_Click" />
        </div>

        <asp:GridView ID="gridUsers" runat="server" AutoGenerateColumns="False" CssClass="table" GridLines="Both">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Përdoruesi ID" />
                <asp:BoundField DataField="username" HeaderText="Emri" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="role" HeaderText="Roli" />
                <asp:TemplateField HeaderText="Veprimet">
                    <ItemTemplate>
                        <a href='<%# Eval("id", "edit_user.aspx?id={0}") %>'>Edito</a>
                        &nbsp;
                        <asp:LinkButton ID="btnDelete" runat="server" Text="Fshi" CommandArgument='<%# Eval("id") %>' OnClick="btnDelete_Click" OnClientClick="return confirm('A jeni i sigurt që dëshironi të fshini këtë përdorues?');" CssClass="actions" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

