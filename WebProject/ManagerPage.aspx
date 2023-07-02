<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerPage.aspx.cs" Inherits="WebProject.ManagerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 1608px;
        }
    </style>
</head>
<body style="height: 1648px">
    <form id="form1" runat="server">
        Tourism IS
        <br />
        <asp:Label ID="emplLabel" runat="server" Text="Пользователь"></asp:Label>
        <br />
        <br />
        <div style="height: 266px; width: 626px">
            Регистрация клиента<br />
            Фамилия<asp:TextBox ID="tbClientF" runat="server" style="margin-left: 58px" Width="140px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Телефон<asp:TextBox ID="tbClientPh" runat="server" style="margin-left: 14px" Width="119px"></asp:TextBox>
            <br />
            Имя<asp:TextBox ID="tbClientI" runat="server" style="margin-left: 92px" Width="142px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Email<asp:TextBox ID="tbClientEm" runat="server" style="margin-left: 39px" Width="119px"></asp:TextBox>
            <br />
            Отчество<asp:TextBox ID="tbClientO" runat="server" style="margin-left: 55px" Width="142px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Пасспорт (серия и номер)
            <asp:TextBox ID="tbClientPass" runat="server" Width="147px"></asp:TextBox>
            <br />
            Дата рождения<asp:TextBox ID="tbClientBirt" runat="server" style="margin-left: 15px"></asp:TextBox>
            <br />
            <asp:Button ID="butClientAdd" runat="server" style="margin-left: 164px" Text="Зарегистрировать и перейти к оформлению" Width="298px" OnClick="butClientAdd_Click" />
            <br />
            <br />
            <asp:Label ID="labelClientMessage" runat="server" BorderStyle="Ridge" ClientIDMode="AutoID" EnableViewState="False" Height="58px" style="margin-top: 0px" Width="613px"></asp:Label>
        </div>
        <br />
        <div style="width: 660px; height: 765px">
            Оформление тура:<br />
            <br />
            Добавить зарегистрированного клиента и тур:<br />
            Номер тура<asp:TextBox ID="tbNumTour" runat="server" style="margin-left: 32px"></asp:TextBox>
&nbsp;<asp:Button ID="butTourCheck" runat="server"  style="margin-left: 10px" Text="Найти тур" Width="118px" OnClick="butTourCheck_Click" />
            &nbsp;&nbsp;&nbsp;
            <br />
            Номер клиента&nbsp; <asp:TextBox ID="tbNumClient" runat="server"></asp:TextBox>
            <asp:Button ID="butClientCheck" runat="server" style="margin-left: 15px" Text="Найти клиента" Width="116px" OnClick="butClientCheck_Click" />
&nbsp;&nbsp;&nbsp; 
            <br />
            <br />
            Выбран тур:<asp:Label ID="labelSelectTour" runat="server"></asp:Label>
            <br />
            Выбран клиент:
            <asp:Label ID="labelSelectClient" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="labelTourClientCheck" runat="server" BorderStyle="Ridge" ClientIDMode="AutoID" EnableViewState="False" Height="58px" style="margin-top: 0px" Width="632px"></asp:Label>
            <br />
            <br />
            Визовое обслуживание:
            <asp:CheckBox ID="checkBoxVisa" runat="server" />
&nbsp;<br />
            <br />
            Туристы участники тура:<br />
            Фамилия<asp:TextBox ID="tbTouristF" runat="server" style="margin-left: 47px" Width="114px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Пасспорт (серия и номер)<asp:TextBox ID="tbTouristPass" runat="server" style="margin-left: 17px"></asp:TextBox>
            <br />
            Имя<asp:TextBox ID="tbTouristI" runat="server" style="margin-left: 82px" Width="111px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Загранпаспорт (9 цифр)
            <asp:TextBox ID="tbTouristInter" runat="server" style="margin-left: 29px"></asp:TextBox>
            <br />
            Отчество<asp:TextBox ID="tbTouristO" runat="server" style="margin-left: 44px" Width="112px"></asp:TextBox>
            <br />
            Дата рождения
            <asp:TextBox ID="tbTouristBirth" runat="server" style="margin-left: 4px" Width="88px"></asp:TextBox>
            <br />
            <asp:Button ID="butTouristAdd" runat="server" style="margin-left: 239px" Text="Добавить" Width="117px" OnClick="butTouristAdd_Click" />
            <br />
            <asp:Label ID="labelTouristMessage" runat="server"></asp:Label>
            <br />
            Список туристов:<br />
            <asp:ListBox ID="listBoxTourist" runat="server" Height="101px" style="margin-left: 10px" Width="638px"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="labelTourOrderMessage" runat="server" BorderStyle="Ridge" ClientIDMode="AutoID" EnableViewState="False" Height="85px" Width="649px"></asp:Label>
            <br />
            Стоимость тура:&nbsp;
            <asp:Label ID="labelPrice" runat="server"></asp:Label>
            <br />
            <asp:Button ID="butOrderAdd" runat="server" OnClick="butOrderAdd_Click" style="margin-left: 229px; margin-top: 0px" Text="Оформить тур" Width="130px" />
            <br />
            <br />
            <asp:Label ID="labelOrderStatus" runat="server"></asp:Label>
        </div>
        <br />
        <div style="width: 733px; height: 559px; margin-top: 22px">
            <div style="height: 454px; margin-top: 0px">
                Список доступных туров:<br />
                <asp:ListBox ID="listBoxTours" runat="server" Height="427px" Width="729px"></asp:ListBox>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
