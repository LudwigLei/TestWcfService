namespace TestWcfService
{
  using SharpArch.NHibernate;

  public class XyzRepository : NHibernateRepository<MyEntity>, IXyzRepository
  {
    public MyEntity GetBySomeProperty(string someProperty)
    {
      return Session.QueryOver<MyEntity>()
        .Where(e => e.SomeProperty == someProperty)
        .SingleOrDefault();
    }
  }
}