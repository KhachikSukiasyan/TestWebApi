using static WebApi.Models.Constants;

namespace WebApi.Interfaces
{
    public interface IPlugin
    {
        public PluginEnum PluginNumber { get; set; }
        public byte[] ApplyPlugin(byte[] image, int? pluginParameter = null);
        public byte[] RemovePlugin(byte[] image, int? pluginParameter = null);
    }
}
