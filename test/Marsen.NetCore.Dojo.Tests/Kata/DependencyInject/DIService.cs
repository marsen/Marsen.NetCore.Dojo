using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata.DependencyInject
{
    public class DIService
    {
        readonly Dictionary<Type, object> instanceLookup = new();
        readonly Dictionary<Type, Func<object>> instanceFuncLookup = new();

        public void Register<T>()
        {
            //// instanceLookup.Add(typeof(T), Activator.CreateInstance(typeof(T)));
            if (instanceFuncLookup.ContainsKey(typeof(T)) == false)
            {
                instanceFuncLookup.Add(typeof(T), () => Activator.CreateInstance(typeof(T)));
            }
        }

        public void Register<S, T>()
        {
            //// instanceLookup.Add(typeof(S), Activator.CreateInstance(typeof(T)));
            if (instanceFuncLookup.ContainsKey(typeof(S)) == false)
            {
                instanceFuncLookup.Add(typeof(S), () => Activator.CreateInstance(typeof(T)));
            }
        }

        public T Resolve<T>()
        {
            var func = instanceFuncLookup.SingleOrDefault(x => x.Key == typeof(T)).Value;
            return (T) func.Invoke();
            ////  return (T) instanceLookup.SingleOrDefault(x => x.Key == typeof(T)).Value;
        }
    }
}