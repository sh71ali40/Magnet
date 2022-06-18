using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magnet.Class.Map
{
    public class Icon
    {
        public string IconUrl { get; set; }
        public string ShadowUrl { get; set; }
        public int[] IconSize { get; set; }
        public int[] ShadowSize { get; set; }
        public int[] IconAnchor { get; set; }
        public int[] ShadowAnchor { get; set; }

    }
}
