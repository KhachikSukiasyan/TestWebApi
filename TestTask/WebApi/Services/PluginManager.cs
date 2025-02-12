using CommonModels;
using DAL;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class PluginManager : IPluginManager
    {
        private DBCRUD _crud;

        private IEnumerable<IPlugin> _plugins;

        public PluginManager(IEnumerable<IPlugin> plugins)
        {
            _crud = new DBCRUD();
            _plugins = plugins;
        }
        public void UploadImage(byte[] image)
        {
            _crud.AddImage(image);
        }


        public byte[] Apply(MainModel model)
        {
            ImageInfoModelCommon currentImagelCommon = _crud.GetImageInfo(model.ImageHashCode!)!;
            byte[]? currentImage = currentImagelCommon?.Image;

            bool isAlreadyApplied;

            foreach (var pm in model.PluginModels)
            {

                foreach (var plugin in _plugins)
                {
                    if (pm.PluginNumber == plugin.PluginNumber)
                    {
                        isAlreadyApplied = currentImagelCommon.PluginInfosCommon.First(x => x.PluginId == (int)plugin.PluginNumber).IsApplied;

                        if (pm.IsApplied && !isAlreadyApplied)
                            currentImage = plugin.ApplyPlugin(currentImage, pm.PluginParameter);
                        if (!pm.IsApplied && isAlreadyApplied)
                            currentImage = plugin.RemovePlugin(currentImage, pm.PluginParameter);
                    }
                }
            }

            return currentImage;
        }

        public void Clear()
        {
            _crud.RemoveAllImageInfos();
        }
    }
}
