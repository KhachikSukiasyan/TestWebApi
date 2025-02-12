using static WebApi.Models.Constants;

namespace WebApi.Models
{
    public class PluginModel
    {
        public PluginEnum PluginNumber { get; set; }
        public bool IsApplied{ get; set; } = false;

        public int? PluginParameter { get; set; }
    }
}
