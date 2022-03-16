using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.BudFaqVM
{
    public class ArticleVM
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}
