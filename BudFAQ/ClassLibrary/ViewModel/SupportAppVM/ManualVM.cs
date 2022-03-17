using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.SupportAppVM
{
    public class ManualVM
    {
        private ManualManager manualManager = new();

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                manualManager.Manual.Title = value;
            }
        }
        private string _link;

        public string Link
        {
            get { return _link; }
            set
            {
                _link = value;
                manualManager.Manual.Link = value;
            }
        }

        public ManualVM()
        {
            Title = manualManager.Manual.Title;
            Link = manualManager.Manual.Link;
        }
    }
}
