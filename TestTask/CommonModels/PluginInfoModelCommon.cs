using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels
{
    public class PluginInfoModelCommon
    {
        public int PluginId { get; set; }
        public bool IsApplied { get; set; }
        public int? PluginParameter { get; set; }
    }
}
