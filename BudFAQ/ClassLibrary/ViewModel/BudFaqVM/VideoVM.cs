using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.BudFaqVM
{
    public class VideoVM
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string link;

        public string Link
        {
            get { return link; }
            set { link = value; }
        }
    }
}
