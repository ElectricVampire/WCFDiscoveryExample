using System;
using System.ServiceModel;

namespace SimpleDiscovery
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://WCFDiscovery")]
    public interface IEmployeeService
    {
        [OperationContract]
        string GetEmployeeInfo(int id);
    }

    // Service class which implements the service contract.    
    public class EmployeeService : IEmployeeService
    {
       
        public string GetEmployeeInfo(int id)
        {
            return "Ashutosh";
        }
    }
}
