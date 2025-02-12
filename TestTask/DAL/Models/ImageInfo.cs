using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ImageInfo
    {
        [Key]
        public int Id { get; set; }
        public int PluginId { get; set; }
        public bool IsApplied { get; set; }
        public  int? PluginParameter { get; set; }
        public Image? Images { get; set; }
    }
}
