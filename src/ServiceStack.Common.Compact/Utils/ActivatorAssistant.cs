using System;
using System.Reflection;

namespace ServiceStack.Common.Utils
{
    public static class ActivatorAssistant
    {
        public static object CreateInstance(Type t, params object[] args)
        {
            Type[] argTypes = new Type[args.Length];

            for (int i = 0; i < args.Length; i++)
                argTypes[i] = args[i] == null ? null : args[i].GetType();

            ConstructorInfo ci = t.GetConstructor(argTypes);

            if (ci == null)
                throw new MissingMethodException();

            return ci.Invoke(args);
        }
    }
}