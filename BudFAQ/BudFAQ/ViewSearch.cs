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
        private ArticleRepository articleRepository;
        private VideoRepository videoRepository;
        public List<ArticleVM> ArticlesFound;
        public List<VideoVM> Videosfound;

        public SearchViewModel()
        {
            articleRepository = new();
            videoRepository = new();
            ArticlesFound = new();
            Videosfound = new();
        }



        private void searchforvideos(string[] keywords)
        {
            foreach (Video video in videoRepository.GetAll())
            {
                foreach (string kword in keywords)
                {
                    if (video.Keywords.Any(stringName => stringName.Contains(kword)))
                    {
                        VideoVM viewVideo = new() { Title = video.Title, Link = video.Link };

                        Videosfound.Add(viewVideo);
                    }
                        
                }
            }
        }

        private void searchForArticles(string[] keywords)
        {
            foreach (Article article in articleRepository.GetAll())
            {
                foreach (string kword in keywords)
                {
                    if (article.Keywords.Any(stringName => stringName.Contains(kword)))
                    {
                        ArticleVM viewArticle = new() { Name = article.Name, Text = article.Text };

                        ArticlesFound.Add(viewArticle);
                        break;
                    }
                        
                }
            }
            
        }

        public void searchquery(string[] keywords)
        {
            ArticlesFound = new(); // nulstille listen
            Videosfound = new(); // nulstille listen

            searchforvideos(keywords);
            searchForArticles(keywords);
        }
    }
}
