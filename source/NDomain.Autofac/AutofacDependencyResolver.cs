﻿using Autofac;
using NDomain.IoC;
using System;

namespace NDomain.Autofac
{
    /// <summary>
    /// IDependencyResolver based on Autofac
    /// </summary>
    public class AutofacDependencyResolver : IDependencyScope
    {
        readonly ILifetimeScope scope;

        public AutofacDependencyResolver(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public IDependencyScope BeginScope()
        {
            return new AutofacDependencyResolver(scope.BeginLifetimeScope());
        }

        public IDependencyScope BeginScope(object tag)
        {
            return new AutofacDependencyResolver(scope.BeginLifetimeScope(tag));
        }

        public object Resolve(Type serviceType)
        {
            return this.scope.Resolve(serviceType);
        }

        public T Resolve<T>()
        {
            return this.scope.Resolve<T>();
        }

        public void Dispose()
        {
            this.scope.Dispose();
        }
    }
}
