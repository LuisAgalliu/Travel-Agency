<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_paketen.aspx.cs" Inherits="agjensi_udhetimi.edit_paketen" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Edito Paketën</title>
    <link rel="stylesheet" href="assets/css/style.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #042f5c;
            color: #fff;
            margin: 0;
            padding: 20px;
        }

        .container {
            background-color: #fff;
            color: #333;
            max-width: 800px;
            margin: auto;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .input, .button {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

        .button {
            background-color: #042f5c;
            color: white;
            border: none;
            cursor: pointer;
        }

        .button:hover {
            background-color: #0056b3;
        }

        .message {
            text-align: center;
            padding: 10px;
            margin-bottom: 10px;
            border-radius: 5px;
            font-weight: bold;
        }

        .success {
            background-color: #d4edda;
            color: #155724;
        }

        .error {
            background-color: #f8d7da;
            color: #721c24;
        }
    </style>
</head>
<body>
    
    

    <div class="container">
        <h1>Edito Paketën</h1>

        <asp:Label ID="lblMessage" runat="server" CssClass="message" EnableViewState="false"></asp:Label>

        <asp:Panel ID="formPanel" runat="server">
            <form id="form1" runat="server">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input" Placeholder="Titulli" required="required" />
                <asp:TextBox ID="txtDestinacion" runat="server" CssClass="input" Placeholder="Destinacioni" required="required" />
                <asp:TextBox ID="txtCmim" runat="server" CssClass="input" Placeholder="Çmimi" TextMode="Number" required="required" />
                <asp:TextBox ID="txtPershkrimi" runat="server" CssClass="input" TextMode="MultiLine" Placeholder="Përshkrimi" required="required" />
                <asp:TextBox ID="txtImage" runat="server" CssClass="input" Placeholder="Emri i imazhit (p.sh. image.jpg)" required="required" />
                <asp:Button ID="btnUpdate" runat="server" Text="Përditëso Paketën" OnClick="btnUpdate_Click" CssClass="button" />
            </form>
        </asp:Panel>
    </div>
</body>
</html>
