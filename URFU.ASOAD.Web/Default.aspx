<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="URFU.ASOAD.Web.Default" Trace="false" EnableEventValidation="true" %>
    
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Новая анкета
    </h2>
    <p>
        <asp:Label runat="server" ID="CourseLabel" AssociatedControlID="CourseTextBox" Text="Курс"
            Font-Bold="true" />
        <asp:TextBox ID="CourseTextBox" runat="server" Text='<%#Questionary.Course %>' />
    </p>
    <p>
        <asp:Label runat="server" ID="LastNameLabel" AssociatedControlID="LastNameTextBox"
            Text="Фамилия" Font-Bold="true" />
        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%#Questionary.Person.LastName %>' />
        <asp:Label runat="server" ID="FirstNameLabel" AssociatedControlID="FirstNameTextBox"
            Text="Имя" Font-Bold="true" />
        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%#Questionary.Person.FirstName %>' />
        <asp:Label runat="server" ID="MiddleNameLabel" AssociatedControlID="MiddleNameTextBox"
            Text="Отчество" Font-Bold="true" />
        <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%#Questionary.Person.MiddleName %>' />
    </p>
    <asp:Button ID="FillButton" runat="server" Text="Отправить" 
        onclick="FillButtonClick" />
</asp:Content>
