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
        [Description("X component of SCP-999 scale vector.")]
        public float ScaleX { get; set; } = 0.6f;
        [Description("Y component of SCP-999 scale vector.")]
        public float ScaleY { get; set; } = 0.6f;
        [Description("Z component of SCP-999 scale vector.")]
        public float ScaleZ { get; set; } = 0.6f;
        [Description("Max percent of health which can be restored by SCP-999.")]
        public int MaxHealPercent { get; set; } = 100;
    }
}
