﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudFAQ
{
    public class ViewArticle
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
