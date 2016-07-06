namespace Common.DIConventions
{
    using System;
    using SimpleInjector;

    public abstract class Convetion
    {
        #region Fields

        protected readonly Container Container;

        #endregion

        #region Constructors and Destructors

        protected Convetion(Container container)
        {
            Container = container;
        }

        #endregion

        #region Public Methods and Operators

        public abstract bool ConditionMet(Type type);

        public abstract void CreateBinding(Type type);

        public abstract Type GetTargetType(Type type);

        #endregion
    }
}