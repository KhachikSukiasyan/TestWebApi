using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IPluginManager
    {
        public void UploadImage(byte[] image);
        public byte[] Apply(MainModel model);
        public void Clear();
    }
}
