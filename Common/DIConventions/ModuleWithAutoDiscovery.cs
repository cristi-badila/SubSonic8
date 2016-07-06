namespace Common.DIConventions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using SimpleInjector;
    using SimpleInjector.Packaging;

    public abstract class ModuleWithAutoDiscovery : IPackage
    {
        #region Fields

        protected readonly List<Convetion> Conventions = new List<Convetion>();

        protected readonly SingletonsCollection Singletons = new SingletonsCollection();

        protected Container Container { get; set; }

        #endregion

        #region Public Methods and Operators

        public void RegisterServices(Container container)
        {
            Container = container;
            PrepareForLoad();
            var singletonTypes = Singletons.SelectMany(singleton => singleton.TypesToBind);
            var types = GetType().GetTypeInfo().Assembly.GetTypes().Except(singletonTypes);
            ApplyConventions(types);
            foreach (var singletonInfo in Singletons)
            {
                foreach (var typeToBind in singletonInfo.TypesToBind)
                {
                    container.RegisterSingleton(typeToBind, singletonInfo.TypeToBindTo);
                }
            }
        }

        #endregion

        #region Methods

        protected abstract void PrepareForLoad();

        private void ApplyConventions(IEnumerable<Type> types)
        {
            foreach (var result in
                types.SelectMany(
                    type => Conventions.Select(c => new { type, convention = c, isMatch = c.ConditionMet(type) }))
                     .Where(result => result.isMatch))
            {
                result.convention.CreateBinding(result.type);
            }
        }

        #endregion
    }
}