using RPSLS.Services.Base;
using RPSLS.UI.Base;

namespace RPSLS.Services
{
    public class UserInterfaceService : ServiceBase
    {
        internal UserInterfaceBase CurrentInterface { get; set; }

        protected override void RegisterService() =>
            Bootstrap.RegisterService(this);
    }
}