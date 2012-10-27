using System;

using URFU.ASOAD.Server;

namespace URFU.ASOAD.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RunTimeManager runTimeManager = Application[typeof(RunTimeManager).Name] as RunTimeManager;
            if (runTimeManager == null)
            {
                System.Diagnostics.Debug.Fail("Отсутствует RunTimeManager");
            }
        }
    }
}
