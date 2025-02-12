using WebApi.Interfaces;
using static WebApi.Models.Constants;

namespace WebApi.Services
{
    public class Plugin1 : IPlugin
    {
        public PluginEnum PluginNumber { get; set; } = PluginEnum.Plugin1;

        public byte[] ApplyPlugin(byte[] image, int? pluginParameter = null)
        {
            throw new NotImplementedException();
        }

        public byte[] RemovePlugin(byte[] image, int? pluginParameter = null)
        {
            throw new NotImplementedException();
        }
    }
}
