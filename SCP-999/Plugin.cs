using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using Handlers = Exiled.Events.Handlers;

namespace SCP_999
{
    public class Plugin : Plugin<PluginConfig>
    {
        public override string Author { get; } = "TrickyBestia";
        public override string Name { get; } = "SCP-999";
        public override string Prefix { get; } = "SCP-999";
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 18);
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override Version Version => Assembly.GetName().Version;

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
