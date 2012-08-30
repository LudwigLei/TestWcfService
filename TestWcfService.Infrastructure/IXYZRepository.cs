namespace TestWcfService
{
  using SharpArch.NHibernate.Contracts.Repositories;

  public interface IXyzRepository : INHibernateRepository<MyEntity>
  {
    MyEntity GetBySomeProperty(string someProperty);
  }
}