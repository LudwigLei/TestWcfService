namespace TestWcfService
{
  using System.Diagnostics;
  using System.ServiceModel;

  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single,InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true)]
  public class Service1 : IService1
  {
    private readonly IXyzRepository xyzRepository;

    public Service1(IXyzRepository xyzRepository)
    {
      this.xyzRepository = xyzRepository;
    }

    public void DoWork()
    {
      var myEntity = xyzRepository.GetBySomeProperty("three");
      Debug.Assert(myEntity != null);
    }
  }
}
