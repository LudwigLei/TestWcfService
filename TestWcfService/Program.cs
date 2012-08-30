namespace TestWcfService
{
  using System;
  using Castle.Facilities.WcfIntegration;
  using Castle.Windsor;

  class Program
  {
    static void Main(string[] args)
    {
      var container = new WindsorContainer();
      IoCInitializer.Initialize(container);

      try
      {
        Initializer.Init();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }

      var factory = new DefaultServiceHostFactory(container.Kernel);
      using (var serviceHost = factory.CreateServiceHost(typeof(IService1).AssemblyQualifiedName, new Uri[0]))
      {
        serviceHost.Open();

        Console.WriteLine("Press return to stop the service ...");
        Console.ReadLine();
      }
    }
  }
}
