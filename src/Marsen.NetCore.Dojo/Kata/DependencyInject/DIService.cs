﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.DependencyInject
{
    public class DIService
    {
        private readonly Dictionary<Type, Func<object>> _instanceFuncLookup = new();

        public void Register<TService>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            Register(typeof(TService), lifetime);
        }

        private void Register(Type instanceType, ServiceLifetime lifetime, Type type = null)
        {
            if (instanceType.IsInterface || instanceType.IsAbstract)
            {
                throw new Exception("Register abstract classes or interfaces, should use Register<Interface,Class>");
            }

            if (type != null)
            {
                if (_instanceFuncLookup.ContainsKey(type))
                    throw new Exception("We not support Register duplicate Type now");

                _instanceFuncLookup.Add(type, () => Activator.CreateInstance(instanceType));
                return;
            }

            if (_instanceFuncLookup.ContainsKey(instanceType))
                throw new Exception("We not support Register duplicate Type now");

            if (lifetime == ServiceLifetime.Singleton)
            {
                var singletonInstance = Activator.CreateInstance(instanceType);
                _instanceFuncLookup.Add(instanceType, () => singletonInstance);
            }
            else
            {
                _instanceFuncLookup.Add(instanceType, () => Activator.CreateInstance(instanceType));
            }
        }

        public void Register<TInterface, TService>(ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TService : TInterface
        {
            Register(typeof(TService), lifetime, typeof(TInterface));
            return;
            var instanceType = typeof(TService);
            var interfaceType = typeof(TInterface);
            if (instanceType.IsInterface || instanceType.IsAbstract)
            {
                throw new Exception("Register abstract classes or interfaces, should use Register<Interface,Class>");
            }

            if (_instanceFuncLookup.ContainsKey(interfaceType))
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