using Shared.BaseTypes;
using System;

namespace BaseTypes.Shared
{
    public class BaseBusinessObject
    {
        public TService FindService<TService>()
        {
            return Ioc.Resolve<TService>();
        }
    }
}
