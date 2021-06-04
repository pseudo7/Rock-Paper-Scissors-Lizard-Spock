using System;
using System.Collections.Generic;
using RPSLS.Miscellaneous;
using RPSLS.Services.Base;
using UnityEngine;

namespace RPSLS.Services
{
    public class Bootstrap
    {
        private static Bootstrap _bootstrapInstance;

        public static Bootstrap BootstrapInstance
            => _bootstrapInstance ??= new Bootstrap();

        internal void RegisterService<T>(T service) where T : ServiceBase
        {
            if (!_serviceMap.ContainsKey(typeof(T)))
            {
                _serviceMap.Add(typeof(T), service);
                Debug.Log($"Registered New Service: {service.GetType().Name}");
            }
            else if (_serviceMap[typeof(T)] == null)
            {
                _serviceMap[typeof(T)] = service;
                Debug.Log($"Registered Existing Service: {service.GetType().Name}");
            }
            else Debug.LogWarning($"Registering Service Again: {service.GetType().Name}".ToColoredString(Color.red));

            GC.Collect();
        }

        internal T GetService<T>() where T : ServiceBase =>
            _serviceMap[typeof(T)] as T;

        private readonly Dictionary<Type, ServiceBase> _serviceMap = new Dictionary<Type, ServiceBase>();
    }
}