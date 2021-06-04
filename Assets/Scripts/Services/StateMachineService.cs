using RPSLS.Services.Base;
using RPSLS.StateMachine;
using RPSLS.StateMachine.States;

namespace RPSLS.Services
{
    public class StateMachineService : ServiceBase
    {
        internal GameplaySystem CurrentFsm { get; private set; }

        protected override void RegisterService()
        {
            CurrentFsm ??= new GameplaySystem(this);
            CurrentFsm.SetState(new InitialState());
            Bootstrap.RegisterService(this);
        }
    }
}