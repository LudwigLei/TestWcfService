namespace TestWcfService
{
  using FluentNHibernate.Automapping;

  using SharpArch.Domain.DomainModel;
  using SharpArch.NHibernate.FluentNHibernate;

  public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
  {
    public AutoPersistenceModel Generate()
    {
      return AutoMap.AssemblyOf<MyEntity>(GetAutomappingConfiguration())
        .IgnoreBase<Entity>()
        .IgnoreBase(typeof(EntityWithTypedId<>))
        .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
    }

    protected virtual IAutomappingConfiguration GetAutomappingConfiguration()
    {
      return new AutomappingConfiguration();
    }
  }
}