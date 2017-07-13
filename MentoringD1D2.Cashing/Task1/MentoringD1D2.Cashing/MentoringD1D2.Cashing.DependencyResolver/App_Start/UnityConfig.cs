using System;
using System.Web.Mvc;
using MentoringD1D2.Cashing.Interfaces;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace MentoringD1D2.Cashing.Resolver
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType(typeof(ICache<int>), typeof(FibonacciSequenceGenerator));
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static object Resolve(Type type)
        {
            var container = new UnityContainer();
            return container.Resolve(type);
        }
    }
}