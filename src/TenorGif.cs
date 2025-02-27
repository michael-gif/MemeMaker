using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeMaker.src
{
    public class TenorGif
    {
        public string tinyUrl { get; set; }
        public string fullUrl { get; set; }
        public int widthTiny { get; set; }
        public int heightTiny { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public TenorGif(string tinyUrl, string fullUrl, int widthTiny, int heightTiny, int width, int height)
        {
            this.tinyUrl = tinyUrl;
            this.fullUrl = fullUrl;
            this.widthTiny = widthTiny;
            this.heightTiny = heightTiny;
            this.width = width;
            this.height = height;
        }
    }
}
