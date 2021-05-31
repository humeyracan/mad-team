using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.BaseTypes
{
    public abstract class IocContainer
    {
        public abstract void RegisterObject<T>(object instance);
        public abstract T ResolveObject<T>();

        public abstract void RegisterType<T>(Type type);
        public abstract Type ResolveType<T>();
        public abstract T Resolve<T>();
    }

    public static class Ioc
    {
        private static readonly IocContainer _container = new Container();

        #region [ Public Methods ]
        public static void RegisterObject<T>(object instance)
        {
            _container.RegisterObject<T>(instance);
        }

        public static T ResolveObject<T>()
        {
            return _container.ResolveObject<T>();
        }

        public static void RegisterType<T>(Type type)
        {
            _container.RegisterType<T>(type);
        }

        public static Type ResolveType<T>()
        {
            return _container.ResolveType<T>();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
        #endregion
    }


    /// <summary>
    /// IoC Container implementation
    /// </summary>
    class Container : IocContainer
    {
        static readonly object _typeLock = new object();
        static readonly object _objectLock = new object();
        private static readonly IDictionary<Type, Type> _typeRegistry = new Dictionary<Type, Type>();
        private static readonly IDictionary<Type, object> _objectRegistry = new Dictionary<Type, object>();

        #region [ Public Methods ]
        public override void RegisterObject<T>(object instance)
        {
            lock (_objectLock)
            {
                _objectRegistry.Add(typeof(T), instance);
            }
        }

        public override T ResolveObject<T>()
        {
            var retVal = default(T);

            var key = typeof(T);
            lock (_objectLock)
            {
                if (_objectRegistry.ContainsKey(key))
                {
                    retVal = (T)_objectRegistry[key];
                }
            }

            return retVal;
        }

        public override void RegisterType<T>(Type type)
        {
            lock (_typeLock)
            {
                _typeRegistry.Add(typeof(T), type);
            }
        }

        public override Type ResolveType<T>()
        {
            Type retVal = null;

            var key = typeof(T);

            if (_typeRegistry.ContainsKey(key))
                retVal = _typeRegistry[key];

            return retVal;
        }

        public override T Resolve<T>()
        {
            var targetType = ResolveType<T>();

            if (targetType!=null)
                return (T)Activator.CreateInstance(targetType);

            return default(T);
        }
        #endregion
    }
}

