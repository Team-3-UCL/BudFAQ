using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudFAQ
{
    class SearchViewModel
    {
        private ArticelRepository articleRepository;
        public List<ViewArticle> ArticlesFound;
        //public list<video> videosfound;

        public SearchViewModel()
        {
            articleRepository = new();
            ArticlesFound = new();
            //videosfound = new();
        }



        //private void searchforvideos(string[] keywords)
        //{
        //    foreach (video video in videorepository.getall())
        //    {
        //        foreach (string kword in keywords)
        //        {
        //            if (video.keywords.contains(kword))
        //                videosfound.add(article);
        //        }
        //    }
        //}

        private void searchForArticles(string[] keywords)
        {
            foreach (Article article in articleRepository.GetAll())
            {
                foreach (string kword in keywords)
                {
                    if (article.Keywords.Contains(kword))
                    {
                        ViewArticle viewArticle = new() { Name = article.Name, Text = article.Text };

                        ArticlesFound.Add(viewArticle);
                        break;
                    }
                        
                }
            }
            
        }

        public void searchquery(string[] keywords)
        {
            ArticlesFound = new(); // nulstille listen
            //videosfound = new(); // nulstille listen

            //searchforvideos(keywords);
            searchForArticles(keywords);
        }
    }
}
