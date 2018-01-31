using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;

namespace SimpleDiscovery
{
    class Program
    {
        public static void Main()
        {
            Uri baseAddress = new Uri("net.tcp://localhost:0/");
            // Uri baseAddress = new Uri("http://localhost/" + Guid.NewGuid().ToString() + "/");
            ServiceHost serviceHost = new ServiceHost(typeof(EmployeeService), baseAddress);

            try
            {
                ServiceEndpoint netTcpEndpoint = serviceHost.AddServiceEndpoint(typeof(IEmployeeService), new NetTcpBinding(), string.Empty);
                // ServiceEndpoint httpEndpoint = serviceHost.AddServiceEndpoint(typeof(IEmployeeService), new WSHttpBinding(), string.Empty);

                // Set the ListenUri mode to unique
                netTcpEndpoint.ListenUriMode = ListenUriMode.Unique;

                // Make the service discoverable over UDP multicast
                serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
                serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());

                serviceHost.Open();

                Console.WriteLine("Service started at {0}", serviceHost.ChannelDispatchers.First().Listener.Uri);

                Console.WriteLine("Press <ENTER> to terminate the service.");
                Console.ReadLine();

                serviceHost.Close();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.Message);
            }

            if (serviceHost.State != CommunicationState.Closed)
            {
                Console.WriteLine("Aborting service...");
                serviceHost.Abort();
            }
        }
    }
}
