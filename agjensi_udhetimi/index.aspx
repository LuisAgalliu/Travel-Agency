<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="agjensi_udhetimi.index" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="headTitle" runat="server">
    Travel Agency
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero">
        <img src="assets/images/hero-banner.jpg" alt="Explore the World" class="hero-image" />
        <div class="hero-text">
            <h1>Zbulo Udhëtimin Tënd të Radhës</h1>
            <p>Planifiko pushimet e tua të ëndrrave me paketat tona ekskluzive të udhëtimit.</p>
            <a href="#paketat" class="btn">Shfleto Paketat</a>
        </div>
    </section>

    <div class="container" id="paketat">
        <h2 style="text-align: center;">Paketat e Disponueshme</h2>
        <div class="paketat-grid"> 
            <asp:Repeater ID="rptPaketat" runat="server">
                <ItemTemplate>
                    <div class="paketa">
                        <img src='<%# Eval("image", "assets/images/{0}") %>' alt='<%# Eval("title") %>' />
                        <h3><%# Eval("title") %></h3>
                        <p><strong>Destinacioni:</strong> <%# Eval("destinacion") %></p>
                        <p><strong>Çmim:</strong> $<%# Eval("cmim") %></p>
                        <p><%# Eval("pershkrimi") %></p>
                        <a href='Rezervimet.aspx?paketa_id=<%# Eval("paketa_id") %>' class="btn">Rezervo Tani</a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>