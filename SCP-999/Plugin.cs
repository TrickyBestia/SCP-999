using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using Handlers = Exiled.Events.Handlers;

namespace SCP_999
{
    public class Plugin : Plugin<PluginConfig>
    {
        public static Plugin Instance { get; private set; }

        public override string Author { get; } = "TrickyBestia";
        public override string Name { get; } = "SCP-999";
        public override string Prefix { get; } = "SCP-999";
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 18);
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override Version Version => Assembly.GetName().Version;

        public Plugin()
        {
            Instance = this;
        }
        public override void OnEnabled()
        {
            Handlers.Server.RestartingRound += OnServerRestartingRound;
            Handlers.Player.ChangingRole += OnPlayerChangingRole;
            Handlers.Player.PickingUpItem += OnPlayerPickingUpItem;
            Handlers.Player.DroppingItem += OnPlayerDroppingItem;
            Handlers.Player.Shooting += OnPlayerShooting;
            Handlers.Player.Shot += OnPlayerShot;

            base.OnEnabled();
        }

        private void OnPlayerShot(ShotEventArgs ev)
        {
            if (Scp999Manager.IsScp999(ev.Shooter))
                ev.Damage = -Config.HealPerShot;
        }
        private void OnPlayerShooting(ShootingEventArgs ev)
        {
            if (Scp999Manager.IsScp999(ev.Shooter))
            {
                var weapon = ev.Shooter.Inventory.items[ev.Shooter.CurrentItemIndex];
                weapon.durability = 1000f;
                ev.Shooter.Inventory.items[ev.Shooter.CurrentItemIndex] = weapon;
            }
        }
        private void OnPlayerDroppingItem(DroppingItemEventArgs ev)
        {
            if (Scp999Manager.IsScp999(ev.Player))
                ev.IsAllowed = false;
        }
        private void OnPlayerPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (Scp999Manager.IsScp999(ev.Player))
                ev.IsAllowed = false;
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
