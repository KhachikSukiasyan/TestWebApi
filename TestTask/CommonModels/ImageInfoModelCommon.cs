namespace CommonModels
{
    public class ImageInfoModelCommon
    {
        public string? ImageHashCode { get; set; }
        public byte[]? Image { get; set; }
        public List<PluginInfoModelCommon>? PluginInfosCommon { get; set; }
    }
}
