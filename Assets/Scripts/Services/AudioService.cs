using RPSLS.Services.Base;

namespace RPSLS.Services
{
    public class AudioService : ServiceBase
    {
        protected override void RegisterService() =>
            Bootstrap.RegisterService(this);

        public void PlayAudio(string keyTag) =>
            throw new System.NotImplementedException();
    }
}