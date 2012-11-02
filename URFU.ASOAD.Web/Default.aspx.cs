using System;

using URFU.ASOAD.Core.Factories;
using URFU.ASOAD.Dto;
using URFU.ASOAD.Web.Model;

namespace URFU.ASOAD.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected Questionary Questionary { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Questionary = QuestionaryFactory.Create();
        }

        protected void FillButtonClick(object sender, EventArgs e)
        {
            Questionary.Course = CourseTextBox.Text;
            Questionary.Person.FirstName = FirstNameTextBox.Text;
            Questionary.Person.MiddleName = MiddleNameTextBox.Text;
            Questionary.Person.LastName = LastNameTextBox.Text;
            QuestionaryWebContext webContext = new QuestionaryWebContext();
            webContext.Add(Questionary);
        }
    }
}
