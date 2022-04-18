using System;
using System.Collections.Generic;
using System.Linq;
using Marsen.NetCore.Dojo.Common;

namespace Marsen.NetCore.Dojo.Kata.DependencyInject;

public class DIService
{
    private readonly Dictionary<Type, Func<object>> _instanceFuncLookup = new();

    public void Register<TService>(ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        Register(typeof(TService), lifetime);
    }

    public void Register<TInterface, TService>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        where TService : TInterface
    {
        Register(typeof(TService), lifetime, typeof(TInterface));
    }

    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }

    private object Resolve(Type type)
    {
        var func = _instanceFuncLookup.SingleOrDefault(x => x.Key == type).Value;
        return func == null ? throw new Exception($"Not Register {type}") : func.Invoke();
    }

    private void Register(Type instanceType, ServiceLifetime lifetime, Type interfaceType = null)
    {
        if (instanceType.IsInterface || instanceType.IsAbstract)
            throw new DojoException("Register abstract classes or interfaces, should use Register<Interface,Class>");

        if (_instanceFuncLookup.ContainsKey(interfaceType ?? instanceType))
            throw new DojoException("We not support Register duplicate Type now");

        var parameters = Array.Empty<object>();
        foreach (var constructor in instanceType.GetConstructors())
            parameters = constructor.GetParameters().Select(x => Resolve(x.ParameterType)).ToArray();

        Func<object> func = () => Activator.CreateInstance(instanceType, parameters);
        if (lifetime == ServiceLifetime.Singleton)
        {
            var singletonInstance = Activator.CreateInstance(instanceType);
            func = () => singletonInstance;
        }

        _instanceFuncLookup.Add(interfaceType ?? instanceType, func);
    }
}