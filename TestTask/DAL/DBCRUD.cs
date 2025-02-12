using CommonModels;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBCRUD
    {
        public ImageInfoModelCommon? GetImageInfo(string hashCode)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var image = db.Images
                            .Include(x => x.ImageInfos)
                            .FirstOrDefault(x => x.ImageHashCode == hashCode);

                if (image == null)
                    return null;

                ImageInfoModelCommon result = new ImageInfoModelCommon();

                result.Image = image.ImageBytes;
                result.ImageHashCode = image.ImageHashCode;
                result.PluginInfosCommon = new List<PluginInfoModelCommon>();

                foreach (var item in image.ImageInfos)
                {
                    result.PluginInfosCommon.Add(new PluginInfoModelCommon
                    {
                        PluginId = item.PluginId,
                        IsApplied = item.IsApplied,
                        PluginParameter = item.PluginParameter,
                    });
                }

                return result;
            }
        }

        public void AddImage(byte[] imageBytes)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                SHA256 sha256Hash = SHA256.Create();
                byte[] bytes = sha256Hash.ComputeHash(imageBytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                Image image = new Image
                {
                    ImageBytes = imageBytes,
                    ImageHashCode = builder.ToString()
                };

                db.Add(image);
                db.SaveChanges();
            }
        }

        public void AddImagePlugins(List<PluginInfoModelCommon> pluginInfoModelCommons)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<ImageInfo> imageInfos = new List<ImageInfo>();

                foreach (var item in pluginInfoModelCommons)
                {
                    imageInfos.Add(new ImageInfo
                    {
                        PluginId = item.PluginId,
                        IsApplied = item.IsApplied,
                        PluginParameter = item.PluginParameter,

                    });
                }

                db.AddRange(imageInfos);
                db.SaveChanges();
            }
        }


        public void RemoveAllImageInfos()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var imageinfos = from io in db.ImageInfos select io;
                foreach (var row in imageinfos)
                {
                    db.ImageInfos.Remove(row);
                }

                var images = from i in db.Images select i;

                foreach (var row in images)
                {
                    db.Images.Remove(row);
                }

                db.SaveChanges();
            }
        }

    }
}
