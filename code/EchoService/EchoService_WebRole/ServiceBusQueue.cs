using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EchoService_WebRole
{
    public class ServiceBusQueue
    {        
        private NamespaceManager namespaceManager = null;
        private QueueDescription queueDescription = null;
        private string name = null;
        private QueueClient client = null;

        public ServiceBusQueue(string name, bool reset)
        {
            this.namespaceManager = NamespaceManager.Create();
            if (reset && this.namespaceManager.QueueExists(name))
            {
                this.namespaceManager.DeleteQueue(name);
                this.queueDescription = this.namespaceManager.CreateQueue(name);
            }
            else
            {
                this.queueDescription = this.namespaceManager.GetQueue(name);
            }
            this.name = name;
            this.client = QueueClient.CreateFromConnectionString(WebConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"], this.name);
        }

        public long SendMessage(object messageBody)
        {
            BrokeredMessage message = new BrokeredMessage(messageBody);
            message.MessageId = Guid.NewGuid().ToString();
            this.client.Send(message);
            return this.queueDescription.MessageCount;
        }
    }
}