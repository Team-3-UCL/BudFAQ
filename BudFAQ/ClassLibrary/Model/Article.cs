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

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private string _link;

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

       public List<string> Keywords { get; set; } = new();
    }
}
