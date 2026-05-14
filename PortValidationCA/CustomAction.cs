using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using WixToolset.Dtf.WindowsInstaller;

namespace PortValidationCA
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult PortValidationCA(Session session)
        {

            string prop = "PORT_IS_FREE";
            session.Log("Begin PortValidationCA");
            string portNoString = session["SITEPORTNO"]; 
            session.Log($"Port Number retrieved: {portNoString}");

            if(string.IsNullOrEmpty(portNoString) || !int.TryParse(portNoString, out int portNo))
            {
                session.Log("Port Number is empty or not a valid number");
                session[prop] = "False";
                return ActionResult.Success;
            }
            //Check with the local machine network settings 
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            var listeners = properties.GetActiveTcpListeners(); 

            bool isInUse = listeners.Any(p=>p.Port== portNo);
            if (isInUse)
            {
                session.Log($"Port {portNo} is in Use");
                session[prop] = "False";
            } else
            {
                session.Log($"Port {portNo} is not in Use or Free");
                session[prop] = "True";
            }
            
            session.Log("End PortValidationCA");
            return ActionResult.Success;
        }
    }
}
