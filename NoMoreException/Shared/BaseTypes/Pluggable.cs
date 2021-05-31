using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.BaseTypes
{
    public interface IPluggable
    {
        void Register();
        void Run();
    }

    public class Pluggable : IPluggable
    {
        public virtual void Register()
        {
            RegisterMapper();
        }

        public virtual void Run()
        {

        }

        public virtual void RegisterMapper()
        {
            MappingContainer.Run(this.GetType().Assembly);
        }
    }
    public interface IObjectMapper
    {
        void Register();
    }
    public delegate void MapObjectHandler<in TSource, in TTarget>(TSource source, TTarget target);
    public static class MappingContainer
    {
        private static IDictionary<string, object> _mappingContainer = new Dictionary<string, object>();

        public static void Run(Assembly asm)
        {
            if (asm!=null)
            {
                var typeList = asm.GetTypes();
                foreach (var t in typeList)
                {
                    if ((typeof(IObjectMapper)).IsAssignableFrom(t.UnderlyingSystemType))
                    {
                        var exec = (IObjectMapper)Activator.CreateInstance(t);
                        exec.Register();
                    }
                }
            }

        }

        public static void Register<TTarget, TSource>(MapObjectHandler<TSource, TTarget> mapping)
        {
            var key = typeof(TSource).FullName + typeof(TTarget).FullName;
            if (!_mappingContainer.ContainsKey(key))
            {
                _mappingContainer[key] = mapping;
            }
        }

        
    }
    public class PluggableAssembly : Attribute
    {
    }
}
