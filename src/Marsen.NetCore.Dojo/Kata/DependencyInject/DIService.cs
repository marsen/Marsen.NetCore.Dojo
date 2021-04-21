﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata.DependencyInject
{
    public class DIService
    {
        private readonly Dictionary<Type, Func<object>> _instanceFuncLookup = new();

        public void Register<TService>()
        {
            if (_instanceFuncLookup.ContainsKey(typeof(TService))) return;
            _instanceFuncLookup.Add(typeof(TService), () => Activator.CreateInstance(typeof(TService)));
        }

        public void Register<TInterface, TService>()
        {
            if (_instanceFuncLookup.ContainsKey(typeof(TInterface))) return;
            _instanceFuncLookup.Add(typeof(TInterface), () => Activator.CreateInstance(typeof(TService)));
        }

        public TService Resolve<TService>()
        {
            var func = _instanceFuncLookup.SingleOrDefault(x => x.Key == typeof(TService)).Value;
            return (TService) func.Invoke();
        }

        public void RegisterSingleton<TService>()
        {
            if (_instanceFuncLookup.ContainsKey(typeof(TService))) return;
            var singletonInstance = Activator.CreateInstance(typeof(TService));
            _instanceFuncLookup.Add(typeof(TService), () => singletonInstance);
        }
    }
}