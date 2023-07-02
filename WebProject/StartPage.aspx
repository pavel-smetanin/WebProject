<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="WebProject.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 412px;
        }
        #Password1 {
            width: 153px;
        }
        #Text1 {
            width: 147px;
        }
        #inputLogin {
            width: 147px;
        }
        #inputPassword {
            width: 146px;
            margin-left: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        Tourism IS<br />
        <br />
        <asp:Label ID="globalMessageLabel" runat="server"></asp:Label>
        <br />
        <br />
        <div style="height: 159px; width: 514px">
            <asp:Label ID="Label1" runat="server" Text="Выполнить вход в систему"></asp:Label>
            <br />
            <br />
            Логин:&nbsp;&nbsp;
            <input id="inputLogin" runat="server" type="text" aria-multiline="False" /><br />
            Пароль:
            <input id="inputPassword" runat="server" type="password" /><br />
            <asp:Button ID="butAutorise" runat="server" style="margin-left: 80px; margin-top: 9px" Text="Вход" Width="96px" OnClick="butAutorise_Click" />
            <br />
            <asp:Label ID="labelAutoriseStatus" runat="server"></asp:Label>
            <div style="height: 90px; margin-top: 30px">
                Внимание! Для смены логина и пароля, а также регистрации в системе обратитесь к администратору Tourism IS.</div>
        </div>
    </form>
</body>
</html>
