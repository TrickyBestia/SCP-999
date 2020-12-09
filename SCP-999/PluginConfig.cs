using Exiled.API.Interfaces;
using System.ComponentModel;

namespace SCP_999
{
    public class PluginConfig : IConfig
    {
        [Description("Should plugin be enabled.")]
        public bool IsEnabled { get; set; } = false;
        [Description("SCP-999 healing weapon type. All types here https://discord.com/channels/656673194693885975/668962626780397569/712320830440472616")]
        public ItemType Weapon { get; set; } = ItemType.GunUSP;
        [Description("Heal per shot.")]
        public int HealPerShot { get; set; } = 5;
    }
}
