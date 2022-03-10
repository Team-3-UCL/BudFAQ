using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Video
    {
        public int VideoID { get; init; }
        public string Title { get; set; }
        public int Length { get; set; }
        public string Link { get; set; }
        public List<string> Keywords { get; set; } = new();
    }
}
