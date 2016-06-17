using System.ServiceModel;
using AOPSampleApp.DataContracts;
using AOPSampleApp.Program_Manager;

namespace AOPSampleApp.Client
{
    public class TestClient : ClientBase<ITestService>, ITestService
    {
        public Person GetPerson()
        {
            return Channel.GetPerson();
        }
    }
}
