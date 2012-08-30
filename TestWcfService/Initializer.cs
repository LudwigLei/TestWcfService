namespace TestWcfService
{
  using SharpArch.NHibernate;

  using SharpArchContrib.Data.NHibernate;

  public static class Initializer
  {
    public static void Init()
    {
      NHibernateSession.Init(new ThreadSessionStorage(),
        new[] { "TestWcfService.Infrastructure.dll" },
        new AutoPersistenceModelGenerator().Generate(),
        "NHibernate.config");
    }
  }
}