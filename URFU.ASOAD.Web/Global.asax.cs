using System;

using URFU.ASOAD.Server;

namespace URFU.ASOAD.Web
{
    public class Global : System.Web.HttpApplication
    {

        private RunTimeManager runTimeManager; //todo убрать, когда будет реализовано на WCF

        void Application_Start(object sender, EventArgs e)
        {
            runTimeManager = RunTimeManager.Instance;
            // Code that runs on application startup
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
