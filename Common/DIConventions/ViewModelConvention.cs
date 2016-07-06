namespace Common.DIConventions
{
    using System;
    using System.Reflection;
    using SimpleInjector;

    public class ViewModelConvention : InterfaceToImplementationBaseConvention
    {
        private const string ViewModeleSufix = "ViewModel";

        #region Constructors and Destructors

        public ViewModelConvention(Container container)
            : base(container)
        {
        }

        #endregion

        #region Public Methods and Operators

        public override bool ConditionMet(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return typeInfo.IsInterface && typeInfo.Name.EndsWith(ViewModeleSufix) && GetTargetType(type) != null;
        }

        public override void CreateBinding(Type type)
        {
            var targetType = GetTargetType(type);

            Container.Register(type, targetType, Lifestyle.Transient);
        }

        #endregion
    }
}