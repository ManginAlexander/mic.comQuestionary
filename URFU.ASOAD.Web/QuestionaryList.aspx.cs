using System;

namespace URFU.ASOAD.Web
{
    public partial class QuestionaryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataBind(); //необходимо в случаях использования DataSource или после редактирования DetailsView
        }

        protected void OnItemUpdating(object sender, System.Web.UI.WebControls.ListViewUpdateEventArgs e)
        {

        }
    }
}
