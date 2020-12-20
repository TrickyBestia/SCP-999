using CommandSystem;
using Exiled.API.Features;
using System;
using Exiled.Permissions.Extensions;

namespace SCP_999.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Spawn999Command : ICommand
    {
        public string Command { get; } = "spawn999";
        public string[] Aliases { get; } = new string[0];
        public string Description { get; } = "Turns player with specified id into SCP-999";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player;
            if (!sender.CheckPermission("spawn999"))
            {
                response = "You don't have enough permissions.";
                return false;
            }
            else if (arguments.Count != 1 || !int.TryParse(arguments.At(0), out int id))
            {
                response = "Command failed, incorrect arguments.\nthe command is spawn999 id";
                return false;
            }
            else if ((player = Player.Get(id)) == null)
            {
                response = $"Player with id {id} can't be found.";
                return false;
            }
            else if (Scp999Manager.IsScp999(player))
            {
                response = "Player is already SCP-999.";
                return false;
            }
            else
            {
                Scp999Manager.MakeScp999(player);
                response = $"Ok, {player.Nickname} is SCP-999 now.";
                return true;
            }
        }
    }
}
