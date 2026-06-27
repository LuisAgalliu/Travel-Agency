<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Konfirmim_Rezervimi.aspx.cs" Inherits="agjensi_udhetimi.Konfirmim_Rezervimi" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Konfirmimi i Rezervimit</title>
    <style>
        /* Konfirmim Rezervimi Page Styling */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            background-color: #f4f4f4;
        }

        .confirmation-container {
            background: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            text-align: center;
            max-width: 500px;
            width: 100%;
        }

        .confirmation-container h1 {
            color: #007BFF;
            font-size: 1.8rem;
            margin-bottom: 20px;
        }

        .confirmation-container p {
            font-size: 1rem;
            margin-bottom: 20px;
        }

        .confirmation-container a {
            text-decoration: none;
            color: white;
            background-color: #007BFF;
            padding: 10px 20px;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }

        .confirmation-container a:hover {
            background-color: #0056b3;
        }

        .success-icon {
            font-size: 50px;
            color: #28a745;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="confirmation-container">
            <div class="success-icon">✔</div>
            <h1>Rezervimi u Konfirmua!</h1>
            <p>Faleminderit që zgjodhët ELITE Travel Agency!</p>
            <asp:HyperLink ID="lnkKthehu" runat="server" NavigateUrl="~/index.aspx" Text="Ktheu në krye" />
        </div>
    </form>
</body>
</html>
