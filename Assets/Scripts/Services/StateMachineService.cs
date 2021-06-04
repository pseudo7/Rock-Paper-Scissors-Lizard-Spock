using RPSLS.Services.Base;
using RPSLS.StateMachine;

namespace RPSLS.Services
{
    public class StateMachineService : ServiceBase
    {
        internal GameplaySystem CurrentFsm { get; private set; }

        protected override void RegisterService()
        {
            CurrentFsm ??= new GameplaySystem(this);
            Bootstrap.RegisterService(this);
        }
    }
}