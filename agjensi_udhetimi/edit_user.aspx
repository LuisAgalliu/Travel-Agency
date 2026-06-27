<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="edit_user.aspx.cs" Inherits="agjensi_udhetimi.edit_user" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="headTitle" runat="server">
    Edito Përdoruesin - Elite Travel Agency
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            background-color: #fff;
            color: #333;
            max-width: 800px;
            margin: auto;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        form input, form select, form button {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

        form button {
            background-color: #042f5c;
            color: white;
            border: none;
            cursor: pointer;
        }

        form button:hover {
            background-color: #0056b3;
        }

        .error, .success {
            text-align: center;
            padding: 10px;
            margin-bottom: 10px;
            border-radius: 5px;
        }

        .error {
            background-color: #f8d7da;
            color: #721c24;
        }

        .success {
            background-color: #d4edda;
            color: #155724;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Edito Përdoruesin</h1>

        <asp:Literal ID="MessageLiteral" runat="server" EnableViewState="false" />

        <asp:TextBox ID="UsernameTextBox" runat="server" placeholder="Emri" CssClass="form-control" required="true" />
        <asp:TextBox ID="EmailTextBox" runat="server" placeholder="Email" CssClass="form-control" TextMode="Email" required="true" />
        <asp:DropDownList ID="RoleDropDown" runat="server" CssClass="form-control">
            <asp:ListItem Value="user" Text="User" />
            <asp:ListItem Value="admin" Text="Admin" />
        </asp:DropDownList>
        <asp:Button ID="UpdateButton" runat="server" Text="Përditëso Përdoruesin" CssClass="btn btn-primary" OnClick="UpdateButton_Click" />
    </div>
</asp:Content>
