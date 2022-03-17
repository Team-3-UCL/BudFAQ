using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel.SupportAppVM;

namespace ViewModel.BudFaqVM
{
    public class SearchViewModel
    {
        private ArticleRepository articleRepository;
        private VideoRepository videoRepository;
        public List<ArticleVM> ArticlesFound { get; set; }
        public List<VideoVM> VideosFound { get; set; }
        public ManualVM Manual { get; set; }

        public SearchViewModel()
        {
            articleRepository = new();
            videoRepository = new();
            ArticlesFound = new();
            VideosFound = new();
            Manual = new()
            {
                Title = new ManualManager().Manual.Title,
                Link = new ManualManager().Manual.Link
            };

        }



        private void SearchForVideos(string[] keywords)
        {
            foreach (Video video in videoRepository.GetAll())
            {
                foreach (string kword in keywords)
                {
                    if (video.BrakeCalipers.Any(brakeCaliper => brakeCaliper.Name.ToUpper().Contains(kword.ToUpper())))
                    {
                        VideoVM viewVideo = new() { Title = video.Title, Link = video.Link };

                        VideosFound.Add(viewVideo);
                    }
                        
                }
            }
        }

        private void SearchForArticles(string[] keywords)
        {
            foreach (Article article in articleRepository.GetAll())
            {
                foreach (string kword in keywords)
                {
                    if (article.BrakeCalipers.Any(brakeCaliper => brakeCaliper.Name.ToUpper().Contains(kword.ToUpper())))
                    {
                        ArticleVM viewArticle = new() { Title = article.Title, Text = article.Text };

                        ArticlesFound.Add(viewArticle);
                        break;
                    }
                        
                }
            }
            
        }

        public void SearchQuery(string[] keywords)
        {
            ArticlesFound = new(); // nulstille listen
            VideosFound = new(); // nulstille listen

            SearchForVideos(keywords);
            SearchForArticles(keywords);
        }
    }
}
