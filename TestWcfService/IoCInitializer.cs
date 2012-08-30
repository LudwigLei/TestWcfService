namespace TestWcfService
{
  using Castle.Facilities.WcfIntegration;
  using Castle.MicroKernel.Registration;
  using Castle.Windsor;

  using CommonServiceLocator.WindsorAdapter;

  using Microsoft.Practices.ServiceLocation;

  using SharpArch.Domain.PersistenceSupport;
  using SharpArch.NHibernate;
  using SharpArch.NHibernate.Contracts.Repositories;

  public static class IoCInitializer
  {
    public static void Initialize(IWindsorContainer container)
    {
      SharpArchContrib.Castle.CastleWindsor.ComponentRegistrar.AddComponentsTo(container);

      container.AddFacility<WcfFacility>();

      AddGenericRepositoriesTo(container);
      AddCustomRepositoriesTo(container);
      AddServicesTo(container);

      ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
    }

    private static void AddCustomRepositoriesTo(IWindsorContainer container)
    {
      container.Register(
        Component.For(typeof(IXyzRepository))
          .ImplementedBy(typeof(XyzRepository))
          .Named("xyzRepository"));
    }

    private static void AddGenericRepositoriesTo(IWindsorContainer container)
    {
      container.Register(
        Component.For(typeof(IEntityDuplicateChecker))
          .ImplementedBy(typeof(EntityDuplicateChecker))
          .Named("entityDuplicateChecker"));

      container.Register(
        Component.For(typeof(INHibernateRepository<>))
          .ImplementedBy(typeof(NHibernateRepository<>))
          .Named("nhibernateRepositoryType"));

      container.Register(
        Component.For(typeof(INHibernateRepositoryWithTypedId<,>))
          .ImplementedBy(typeof(NHibernateRepositoryWithTypedId<,>))
          .Named("nhibernateRepositoryWithTypedId"));

      container.Register(
        Component.For(typeof(ISessionFactoryKeyProvider))
          .ImplementedBy(typeof(DefaultSessionFactoryKeyProvider))
          .Named("sessionFactoryKeyProvider"));
    }

    private static void AddServicesTo(IWindsorContainer container)
    {
      container.Register(
        Component.For(typeof(IService1))
          .ImplementedBy(typeof(Service1))
          .Named("service1"));
    }
  }
}