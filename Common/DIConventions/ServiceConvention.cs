namespace Common.DIConventions
{
    using System;
    using System.Reflection;
    using SimpleInjector;

    public class ServiceConvention : InterfaceToImplementationBaseConvention
    {
        private const string ServiceSuffix = "Service";

        #region Constructors and Destructors

        public ServiceConvention(Container container)
            : base(container)
        {
        }

        #endregion

        #region Public Methods and Operators

        public override bool ConditionMet(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return typeInfo.IsInterface && typeInfo.Name.EndsWith(ServiceSuffix) && GetTargetType(type) != null;
        }

        public override void CreateBinding(Type type)
        {
            var targetType = GetTargetType(type);
            Container.RegisterSingleton(type, targetType);
        }

        #endregion
    }
}