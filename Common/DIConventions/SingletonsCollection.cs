namespace Common.DIConventions
{
    using System;
    using System.Collections.Generic;

    public class SingletonsCollection : List<SingletonInfo>
    {
        public void Add<TInterface, TImplementation>(bool bindAlsoToImplementation = false)
        {
            var typesToBind = new List<Type> { typeof(TInterface) };
            if (bindAlsoToImplementation)
            {
                typesToBind.Add(typeof(TImplementation));
            }

            Add(new SingletonInfo(typesToBind, typeof(TImplementation)));
        }
    }
}