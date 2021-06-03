using BusinessLayer.BusinessObject;
using BusinessLayer.Interfaces;
using Shared.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AppPlugin : Pluggable
    {
        public override void Register()
        {
            base.Register();


            // Interface Register (Contract Implementation) 
            //

            Ioc.RegisterType<ILabelObject>(typeof(LabelObject));
            //Ioc.RegisterType<IUserObject>(typeof(UserObject));
            //Ioc.RegisterType<IAttachmentObject>(typeof(AttachmentObject));
        }

    }
}
