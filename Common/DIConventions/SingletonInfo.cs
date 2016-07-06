namespace Common.DIConventions
{
    using System;
    using System.Collections.Generic;

    public class SingletonInfo
    {
        public IEnumerable<Type> TypesToBind { get; set; }

        public Type TypeToBindTo { get; set; }

        public SingletonInfo(IEnumerable<Type> typesToBind, Type typeToBindTo)
        {
            TypesToBind = typesToBind;
            TypeToBindTo = typeToBindTo;
        }
    }
}