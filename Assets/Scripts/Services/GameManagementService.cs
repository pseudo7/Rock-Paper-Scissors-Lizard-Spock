using RPSLS.Miscellaneous;
using RPSLS.Services.Base;

namespace RPSLS.Services
{
    public class GameManagementService : ServiceBase
    {
        internal GameEnums.PlayableHandType CurrentPlayerSelection { get; set; }

        protected override void RegisterService() =>
            Bootstrap.RegisterService(this);
    }
}