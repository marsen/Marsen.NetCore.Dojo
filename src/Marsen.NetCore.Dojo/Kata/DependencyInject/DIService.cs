using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.DependencyInject
{
    public class DIService
    {
        private readonly Dictionary<Type, Func<object>> _instanceFuncLookup = new();

        public void Register<TService>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (typeof(TService).IsInterface || typeof(TService).IsAbstract)
            {
                throw new Exception("Register abstract classes or interfaces, should use Register<Interface,Class>");
            }

            if (_instanceFuncLookup.ContainsKey(typeof(TService)))
                throw new Exception("We not support Register duplicate Type now");
            if (lifetime == ServiceLifetime.Singleton)
            {
                var singletonInstance = Activator.CreateInstance(typeof(TService));
                _instanceFuncLookup.Add(typeof(TService), () => singletonInstance);
            }
            else
            {
                _instanceFuncLookup.Add(typeof(TService), () => Activator.CreateInstance(typeof(TService)));
            }
        }

        public void Register<TInterface, TService>(ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TService : TInterface
        {
            if (_instanceFuncLookup.ContainsKey(typeof(TInterface)))
                throw new Exception("We not support Register duplicate Type now");
            _instanceFuncLookup.Add(typeof(TInterface), () => Activator.CreateInstance(typeof(TService)));
        }

        public TService Resolve<TService>()
        {
            var func = _instanceFuncLookup.SingleOrDefault(x => x.Key == typeof(TService)).Value;
            if (func == null)
            {
                throw new Exception($"Not Register {typeof(TService)}");
            }

            return (TService) func.Invoke();
        }
    }
}