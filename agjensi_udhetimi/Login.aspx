<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="agjensi_udhetimi.Login" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="headTitle" runat="server">
    Identifikohu - Elite Travel Agency
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            max-width: 400px;
            width: 100%;
            margin: 50px auto;
        }
        .form-container h2 {
            margin-bottom: 20px;
            text-align: center;
        }
        .form-container input {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-sizing: border-box;
        }
        .form-container button {
            width: 100%;
            padding: 10px;
            background-color: #007BFF;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .form-container button:hover {
            background-color: #0056b3;
        }
        .form-container .toggle {
            text-align: center;
            margin-top: 10px;
        }
        .form-container .toggle a {
            color: #007BFF;
            text-decoration: none;
        }
        .form-container .toggle a:hover {
            text-decoration: underline;
        }
        .error, .success {
            color: red;
            text-align: center;
            margin-top: 10px;
        }
        .success {
            color: green;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2 id="formTitle" runat="server">Identifikohu</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>

        <asp:Panel ID="pnlLogin" runat="server">
            <asp:TextBox ID="txtUsername" runat="server" Placeholder="Emri" required="true" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" required="true" />
            <asp:Button ID="btnLogin" runat="server" Text="Identifikohu" OnClick="btnLogin_Click" />
        </asp:Panel>

        <asp:Panel ID="pnlRegister" runat="server" Visible="false">
            <asp:TextBox ID="txtRegUsername" runat="server" Placeholder="Emri" required="true" />
            <asp:TextBox ID="txtRegEmail" runat="server" Placeholder="Email" TextMode="Email" required="true" />
            <asp:TextBox ID="txtRegPassword" runat="server" TextMode="Password" Placeholder="Password" required="true" />
            <asp:Button ID="btnRegister" runat="server" Text="Regjistrohuni" OnClick="btnRegister_Click" />
        </asp:Panel>

        <div class="toggle">
            <asp:LinkButton ID="lnkToggle" runat="server" OnClick="lnkToggle_Click" />
        </div>

        <asp:HiddenField ID="hdnFormState" runat="server" Value="login" />
    </div>
</asp:Content>
