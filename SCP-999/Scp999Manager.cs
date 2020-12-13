using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SCP_999
{
    public static class Scp999Manager
    {
        private static List<Scp999> _scps;

        static Scp999Manager()
        {
            _scps = new List<Scp999>();
        }
        public static void Clear()
        {
            List<Scp999> scps = new List<Scp999>(_scps);
            foreach (var scp in scps)
            {
                Player player = Player.Get(scp.UserId);
                if (player != null)
                    UnMakeScp999(player);
            }
        }
        public static bool IsScp999(Player player) => _scps.Any(scp => scp.UserId == player.UserId);
        public static void MakeScp999(Player player)
        {
            if (IsScp999(player))
                throw new InvalidOperationException("Player is already SCP-999");
            Timing.RunCoroutine(MakeScp999Coroutine(player));
        }
        public static void UnMakeScp999(Player player)
        {
            if (!IsScp999(player))
                throw new InvalidOperationException("Player is not SCP-999");
            player.Scale = Vector3.one;
            player.IsGodModeEnabled = false;
            Scp999 scp = _scps.First(scp999 => scp999.UserId == player.UserId);
            player.RankName = scp.PreviousRank;
            _scps.Remove(scp);
        }
        private static IEnumerator<float> MakeScp999Coroutine(Player player)
        {
            Vector3? currentPosition = null;
            if (player.IsAlive)
                currentPosition = player.GameObject.transform.position;
            player.SetRole(RoleType.Tutorial);
            player.Inventory.AddNewItem(Plugin.Instance.Config.Weapon);
            player.IsGodModeEnabled = true;
            yield return Timing.WaitForSeconds(0.2f);
            player.Scale = new Vector3(Plugin.Instance.Config.ScaleX, Plugin.Instance.Config.ScaleY, Plugin.Instance.Config.ScaleZ);
            yield return Timing.WaitForSeconds(0.2f);
            if (currentPosition.HasValue)
                player.Position = currentPosition.Value;
            _scps.Add(new Scp999(player.UserId, player.RankName));
            player.RankName = "SCP-999";
        }
    }
}
