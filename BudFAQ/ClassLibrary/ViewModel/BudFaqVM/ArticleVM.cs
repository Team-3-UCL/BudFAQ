using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.BudFaqVM
{
    public class ArticleVM
    {
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
    }
}
