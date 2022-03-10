using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article
    {
        public int ArticleID { get; init; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string link;

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

       public List<string> Keywords { get; set; } = new();
    }
}
