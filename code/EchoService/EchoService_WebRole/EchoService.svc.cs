using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EchoService_WebRole
{
    public class EchoService : IEchoService
    {
        public string EchoGet(string message)
        {
            return "[" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "] EchoGet(): " + message;
        }

        public string EchoPost(string message)
        {
            return "[" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "] EchoPost(): " + message;
        }
    }
}
