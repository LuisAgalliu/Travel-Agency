<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="Rezervimet.aspx.cs" Inherits="agjensi_udhetimi.Rezervimet" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="headTitle" runat="server">
    Rezervimet - Elite Travel Agency
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .rezervimi-wrapper {
            max-width: 1100px;
            margin: 50px auto;
            padding: 20px;
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 40px;
            align-items: start;
            background: #fff;
            border-radius: 15px;
            box-shadow: 0 8px 16px rgba(0,0,0,0.1);
        }

        .paketa-info {
            text-align: left;
        }

        .paketa-info img {
            width: 100%;
            border-radius: 12px;
            margin-bottom: 15px;
        }

        .paketa-info h2 {
            margin-top: 0;
            font-size: 1.8rem;
            color: #333;
        }

        .paketa-info p {
            font-size: 1rem;
            color: #666;
        }

        .rezervim-form {
            background-color: #f5f5f5;
            padding: 25px;
            border-radius: 12px;
        }

        .rezervim-form h3 {
            margin-bottom: 20px;
            font-size: 1.5rem;
            text-align: center;
            color: #333;
        }

        .rezervim-form input {
            width: 100%;
            padding: 12px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 8px;
            font-size: 1rem;
            box-sizing: border-box;
        }

        .rezervim-form .btn {
            width: 100%;
            padding: 12px;
            font-size: 1rem;
            font-weight: bold;
            text-align: center;
        }

        @media (max-width: 768px) {
            .rezervimi-wrapper {
                grid-template-columns: 1fr;
            }
        }
    </style>

    <div class="rezervimi-wrapper">
        <div class="paketa-info paketa">
            <asp:Image ID="imgPaketa" runat="server" CssClass="paketa-image" />
            <h2><asp:Label ID="lblTitulli" runat="server" /></h2>
            <p><strong>Destinacioni:</strong> <asp:Label ID="lblDestinacioni" runat="server" /></p>
            <p><strong>Çmimi:</strong> $<asp:Label ID="lblCmimi" runat="server" /></p>
            <p><asp:Label ID="lblPershkrimi" runat="server" /></p>
        </div>

        <div class="rezervim-form">
            <h3>Konfirmo Rezervimin</h3>
            <asp:TextBox ID="txtEmriKartes" runat="server" Placeholder="Emri i Mbajtësit të Kartës" required="true" />
            <asp:TextBox ID="txtNumriKartes" runat="server" Placeholder="Numri i Kartës (16 shifra)" MaxLength="16" TextMode="Number" required="true" />
            <asp:RegularExpressionValidator ID="revNumriKartes" runat="server" 
                ControlToValidate="txtNumriKartes" 
                ErrorMessage="Numri i kartës duhet të jetë 16 shifra!" 
                ValidationExpression="^\d{16}$" 
                ForeColor="Red" 
                Display="Dynamic" />
            <asp:Button ID="btnKonfirmo" runat="server" Text="Konfirmo Rezervimin" OnClick="btnKonfirmo_Click" CssClass="btn" />
            <asp:Label ID="lblMesazh" runat="server" ForeColor="Green" />
        </div>
    </div>
</asp:Content>

