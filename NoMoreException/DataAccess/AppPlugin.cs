using DataAccess.DataModels;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Shared.BaseTypes;

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
            //Ioc.RegisterType<IUserRepository>(typeof(UserRepository));
            Ioc.RegisterType<IAttachmentRepository>(typeof(AttachmentRepository));
            Ioc.RegisterType<IRepository<Base>>(typeof(Repository<Base>));
            Ioc.RegisterType<IVoteRepository>(typeof(VoteRepository));
            Ioc.RegisterType<IPostRepository>(typeof(PostRepository));


        }
    }
}
