using RPSLS.Services.Base;

namespace RPSLS.Services
{
    public class AssetService : ServiceBase
    {
        protected override void RegisterService() =>
            Bootstrap.BootstrapInstance.RegisterService(this);
    }
}