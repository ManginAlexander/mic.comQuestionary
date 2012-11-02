<%@ Page Title="Список анкет" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="QuestionaryList.aspx.cs" Inherits="URFU.ASOAD.Web.QuestionaryList" %>
<%@ Import Namespace="URFU.ASOAD.Dto" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Список анкетных данных
    </h2>
    <p>
    <asp:ObjectDataSource ID="QuestionaryDataSource" runat="server" 
            DataObjectTypeName="URFU.ASOAD.Dto.Questionary" InsertMethod="Add" 
            SelectMethod="AllQuestionaries" 
            TypeName="URFU.ASOAD.Web.Model.QuestionaryWebContext" UpdateMethod="Change">
        </asp:ObjectDataSource>
        <asp:ListView ID="QuestionaryListView" DataSourceID="QuestionaryDataSource" 
            DataKeyNames="ID" runat="server" onitemupdating="OnItemUpdating">
            <ItemTemplate>
                <asp:Label ID="CourseLabel" runat="server" Text='<%#Eval("Course") %>' />
                <b>Ф.И.О.: </b>
                <asp:Label ID="FullNameLabel" runat="server" Text='<%# ((Questionary)Container.DataItem).Person.FullName %>' /><br/>
                <b>Дата рождения: </b>
                <asp:Label ID="BirthdayLabel" runat="server" Text='<%# ((Questionary)Container.DataItem).Person.Birthday %>' /><br/>
                <asp:Button ID="EditButton" runat="server" Text="Редактировать" CommandName="Edit" />
                <hr/>
            </ItemTemplate>
            <!-- шаблон редактирования демонстрирует, что биндинг работает через рефлекшн только на одном уровне объекта!!! -->
            <EditItemTemplate>
                <p>
                    <asp:Label runat="server" ID="CourseLabel" AssociatedControlID="CourseTextBox" Text="Курс"
                        Font-Bold="true" />
                    <asp:TextBox ID="CourseTextBox" runat="server" Text='<%# Bind("Course") %>' />
                </p>
                <p>
                    <asp:Label runat="server" ID="LastNameLabel" AssociatedControlID="LastNameTextBox"
                        Text="Фамилия" Font-Bold="true" />
                    <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# ((Questionary)Container.DataItem).Person.LastName %>' />
                    <asp:Label runat="server" ID="FirstNameLabel" AssociatedControlID="FirstNameTextBox"
                        Text="Имя" Font-Bold="true" />
                    <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# ((Questionary)Container.DataItem).Person.FirstName %>' />
                    <asp:Label runat="server" ID="MiddleNameLabel" AssociatedControlID="MiddleNameTextBox"
                        Text="Отчество" Font-Bold="true" />
                    <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# ((Questionary)Container.DataItem).Person.MiddleName %>' />
                </p>

                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Сохранить" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Отмена" />
                <hr/>
            </EditItemTemplate>
        </asp:ListView>
    </p>
</asp:Content>
