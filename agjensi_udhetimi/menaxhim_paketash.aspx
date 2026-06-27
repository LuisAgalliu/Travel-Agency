<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="menaxhim_paketash.aspx.cs" Inherits="agjensi_udhetimi.menaxhim_paketash" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="headTitle" runat="server">
    Menaxho Paketat - Elite Travel Agency
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #042f5c;
            margin: 0;
            padding: 20px;
        }

        .container {
            max-width: 1200px;
            margin: auto;
            background: white;
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

        .form-container {
            margin: 20px 0;
        }

        .form-container input, .form-container textarea {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .form-container button {
            padding: 10px 20px;
            background-color: #042f5c;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .form-container button:hover {
            background-color: #0056b3;
        }

        .actions a {
            text-decoration: none;
            color: white;
            background-color: #dc3545;
            padding: 5px 10px;
            border-radius: 5px;
            margin-right: 5px;
        }

        .actions a:hover {
            background-color: #c82333;
        }

        h1, h2 {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Menaxho Paketat</h1>

        <asp:Label ID="lblMessage" runat="server" CssClass="" Visible="false"></asp:Label>

        <div class="form-container">
            <h2>Shto një Paketë të Re</h2>
            <asp:TextBox ID="txtTitle" runat="server" Placeholder="Titulli" Required="true"></asp:TextBox>
            <asp:TextBox ID="txtDestinacion" runat="server" Placeholder="Destinacioni" Required="true"></asp:TextBox>
            <asp:TextBox ID="txtCmim" runat="server" Placeholder="Çmimi" TextMode="Number" step="0.01" Required="true"></asp:TextBox>
            <asp:TextBox ID="txtPershkrimi" runat="server" Placeholder="Përshkrimi" TextMode="MultiLine" Rows="4" Required="true"></asp:TextBox>
            <asp:TextBox ID="txtImage" runat="server" Placeholder="Emri i Skedarit të Imazhit (p.sh., image.jpg)" Required="true"></asp:TextBox>
            <asp:Button ID="btnAddPaketa" runat="server" Text="Shto Paketën" OnClick="btnAddPaketa_Click" CssClass="form-container button" />
        </div>

        <h2>Paketat Ekzistuese</h2>
        <asp:GridView ID="gvPaketat" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="gvPaketat_RowCommand">
            <Columns>
                <asp:BoundField DataField="paketa_id" HeaderText="Paketa ID" />
                <asp:BoundField DataField="title" HeaderText="Titulli" />
                <asp:BoundField DataField="destinacion" HeaderText="Destinacioni" />
                <asp:TemplateField HeaderText="Çmimi">
                    <ItemTemplate>
                        $<%# Eval("cmim") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="pershkrimi" HeaderText="Përshkrimi" />
                <asp:BoundField DataField="image" HeaderText="Imazhi" />
                <asp:TemplateField HeaderText="Veprime">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="EditPaketa" CommandArgument='<%# Eval("paketa_id") %>' CssClass="actions"></asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Fshi" CommandName="DeletePaketa" CommandArgument='<%# Eval("paketa_id") %>' OnClientClick="return confirm('A jeni i sigurt që dëshironi të fshini këtë paketë?');" CssClass="actions"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
