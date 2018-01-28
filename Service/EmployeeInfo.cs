//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.ServiceModel;

namespace Microsoft.Samples.Discovery
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
