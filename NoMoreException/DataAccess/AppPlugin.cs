using DataAccess.Interfaces;
using DataAccess.Repositories;
using Shared.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppPlugin : Pluggable
    {
        public override void Register()
        {
            base.Register();


            // Interface Register (Contract Implementation) 
            //
            Ioc.RegisterType<ILabelRepository>(typeof(LabelRepository));
        }
    }
}
