<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="agjensi_udhetimi.admin" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="headTitle" runat="server">
    Admin Dashboard - Elite Travel Agency
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .stats {
            display: flex;
            justify-content: space-around;
            margin: 20px;
        }

        .stat-card {
            background-color: rgb(4, 47, 92);
            color: white;
            padding: 20px;
            border-radius: 10px;
            text-align: center;
            width: 30%;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .buttons {
            text-align: center;
            margin: 20px;
        }

        .buttons a, .buttons .logout {
            background-color: #042f5c;
            color: white;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 5px;
            margin: 5px;
        }

        .buttons .logout {
            background-color: #dc3545;
        }

        .buttons .logout:hover {
            background-color: #c82333;
        }

        .recent-bookings-container {
            max-width: 600px;
            margin: 20px auto;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 20px;
            text-align: center;
        }

        .recent-bookings-container ul {
            list-style-type: none;
            padding: 0;
        }

        .recent-bookings-container ul li {
            padding: 10px;
            border-bottom: 1px solid #ddd;
            color: #555;
        }

        h2 {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="stats">
        <div class="stat-card">
            <h3>Paketat</h3>
            <asp:Label ID="lblPaketat" runat="server" Text=""></asp:Label>
        </div>
        <div class="stat-card">
            <h3>Klientët</h3>
            <asp:Label ID="lblUsers" runat="server" Text=""></asp:Label>
        </div>
        <div class="stat-card">
            <h3>Rezervimet</h3>
            <asp:Label ID="lblRezervimet" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="recent-bookings-container">
        <h2>Rezervimet e Fundit</h2>
        <asp:BulletedList ID="lstRecentBookings" runat="server"></asp:BulletedList>
    </div>

    <div class="buttons">
        <asp:LinkButton ID="lnkLogout" runat="server" CssClass="logout" OnClick="lnkLogout_Click">Dil</asp:LinkButton>
    </div>
</asp:Content>
