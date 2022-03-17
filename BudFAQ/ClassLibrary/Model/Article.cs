using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Article
    {
        public int ArticleID { get; init; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public List<BrakeCaliper> BrakeCalipers { get; set; } = new();
    }
}
