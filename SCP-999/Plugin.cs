using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Handlers = Exiled.Events.Handlers;

namespace SCP_999
{
    public class Plugin : Plugin<PluginConfig>
    {
        public override void OnEnabled()
        {
            Handlers.Server.RestartingRound += OnServerRestartingRound;
            Handlers.Player.ChangingRole += OnPlayerChangingRole;

            base.OnEnabled();
        }
        private void OnPlayerChangingRole(ChangingRoleEventArgs ev)
        {
            if (Scp999Manager.IsScp999(ev.Player))
                Scp999Manager.UnMakeScp999(ev.Player);
        }
        private void OnServerRestartingRound()
        {
            Scp999Manager.Clear();
        }
    }
}
