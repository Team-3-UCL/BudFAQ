using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudFAQ
{
    class ViewSearch
    {
         public List<Artikel> ArticlesFound;
         public List<Video> VideosFound;

        public ViewSearch()
        {
            ArticlesFound = new();
             VideosFound = new();
        }

        public void SearchQuery(string[] keyWords)
        {
            ArticlesFound = new(); // nulstille listen
            VideosFound = new(); // nulstille listen


        }

        private void SearchForVideos(string[] keyWords)
        {
            foreach(Artikel article in ArticelRepository)
            {
                foreach(string kWord in keyWords)
                {
                    if (article.keywords.contains(kWord))
                        ArticlesFound.Add(article);
                }
            }
        }

        private void SearchForArticles(string[] keyWords)
        {
            foreach (Video video in VideoRepository)
            {
                foreach (string kWord in keyWords)
                {
                    if (video.keywords.contains(kWord))
                        VideosFound.Add(article);
                }
            }
        }
    }
}
