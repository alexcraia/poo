<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quiz.aspx.cs" Inherits="quiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Utilizarea modelului Project Based Learning (PBL) in educatia biotehnologica</title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css"/>
    <link href="css/style.css" rel="stylesheet" type="text/css"/>
    <style type="text/css">
        .auto-style2 {
            width: 128px;
            height: 49px;
        }
        .auto-style3 {
            height: 49px;
        }
        .auto-style4 {
            width: 128px;
            height: 51px;
        }
        .auto-style5 {
            height: 51px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="full-container">
        <div id="top-bar"></div>
    </div>
    <header>
        <div class="container">
            <h1 class="pull-left"><a href="index.html">PBL in educatia biotehnologica</a></h1>

            <ul class="nav nav-pills pull-right" id="menu">
              <li class="active"><a href="#">Acasa</a></li>
              <li><a href="documentatie.html">Documentatie</a></li>
              <li><a href="#">Start quiz</a></li>
              <li><a href="#">Contact</a></li>
            </ul>
        </div>
    </header>

    <div class="container">
        <div class="pull-right" id="content">
            <asp:Panel ID="Panel1" runat="server">
                <br />
                <asp:Label ID="Label1" runat="server" Font-Size="20px" Text="Va rog introduceti nume si email-ul dumneavoastra"></asp:Label>
                <br />
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style2">Numele:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="textBoxNume" runat="server" Width="293px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Adresa de email:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="textBoxEmail" runat="server" Width="292px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="buttonStart" runat="server" OnClick="buttonStart_Click" Text="Start" Width="106px" />
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                <div style="display:block;"></div><asp:Label ID="nreIntrebareTextBox" runat="server" Text="INTREBAREA 1/11" Font-Size="20px"></asp:Label>
                <div style="float:right;"><asp:Label ID="nrPuncteTextBox" runat="server" Text="Ati obtinut 0 puncte pana acum" Font-Size="18px"></asp:Label></div>
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="intrebareTextBox" runat="server" Font-Size="16px" Text="Care este legea lui Monode?"></asp:Label>
                <br />
            </asp:Panel>
            <br />
            
        </div>

    </div>
    </form>
</body>
</html>
