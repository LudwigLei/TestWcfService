namespace TestWcfService
{
  using System;

  using FluentNHibernate;
  using FluentNHibernate.Automapping;

  using SharpArch.Domain.DomainModel;

  public class AutomappingConfiguration : DefaultAutomappingConfiguration
  {
    public override bool AbstractClassIsLayerSupertype(Type type)
    {
      return type == typeof(EntityWithTypedId<>) || type == typeof(Entity);
    }

    public override bool IsId(Member member)
    {
      return member.Name == "Id";
    }

    public override bool IsComponent(Type type)
    {
      return type.BaseType == typeof(ValueObject);
    }
  }
}
