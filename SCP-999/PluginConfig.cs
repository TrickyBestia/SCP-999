using Exiled.API.Interfaces;
using System.ComponentModel;

namespace SCP_999
{
    public class PluginConfig : IConfig
    {
        [Description("Should plugin be enabled.")]
        public bool IsEnabled { get; set; } = false;
    }
}
