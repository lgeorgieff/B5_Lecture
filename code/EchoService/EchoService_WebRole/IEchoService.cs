using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EchoService_WebRole
{
    [ServiceContract]
    public interface IEchoService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "echo-get/{message}")]
        string EchoGet(string message);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   UriTemplate = "echo-post",
                   ResponseFormat = WebMessageFormat.Json)]
        string EchoPost(string message);
    }
}
