namespace WebApi.Models
{
    public class MainModel
    {
        public byte[]? Image { get; set; }
        public string? ImageHashCode { get; set; }

        public List<PluginModel>? PluginModels { get; set; }
    }
}
