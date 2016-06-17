using System.ServiceModel;
using AOPSampleApp.DataContracts;

namespace AOPSampleApp.Program_Manager
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        Person GetPerson();
    }
}