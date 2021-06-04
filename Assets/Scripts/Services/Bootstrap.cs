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

        private static Bootstrap BootstrapInstance
            => _bootstrapInstance ??= new Bootstrap();

        internal static void RegisterService<T>(T service) where T : ServiceBase
        {
            if (!BootstrapInstance._serviceMap.ContainsKey(typeof(T)))
            {
                BootstrapInstance._serviceMap.Add(typeof(T), service);
                Debug.Log($"Registered New Service: {service.GetType().Name}");
            }
            else if (BootstrapInstance._serviceMap[typeof(T)] == null)
            {
                BootstrapInstance._serviceMap[typeof(T)] = service;
                Debug.Log($"Registered Existing Service: {service.GetType().Name}");
            }
            else Debug.LogWarning($"Registering Service Again: {service.GetType().Name}".ToColoredString(Color.red));

            GC.Collect();
        }

        internal static T GetService<T>() where T : ServiceBase =>
            BootstrapInstance._serviceMap[typeof(T)] as T;

        private readonly Dictionary<Type, ServiceBase> _serviceMap = new Dictionary<Type, ServiceBase>();
    }
}