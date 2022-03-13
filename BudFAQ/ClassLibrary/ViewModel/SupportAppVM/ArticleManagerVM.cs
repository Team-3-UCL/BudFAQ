using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Model;
using System.Collections.ObjectModel;

namespace ViewModel.SupportAppVM
{
    public class ArticleManagerVM
    {
        ArticleRepository articleRepository;
        public Article ChosenArticle { get; set; }
        public ObservableCollection<Article> Articles { get; set; }

        public void AddDefaultArticle()
        {
            articleRepository.Add("specify", "specify", "specify");
            Articles.Add(articleRepository.GetAll().Last());
            
        }

        public void DeleteSelectedArticle()
        {
            Articles.Remove(ChosenArticle);
            articleRepository.Remove(ChosenArticle.ArticleID);

        }

        public void UpdateSelectedArticle()
        {
            if(ChosenArticle != null)
            {
                articleRepository.Update(ChosenArticle.ArticleID, ChosenArticle);
            }
            Articles = new(articleRepository.GetAll());
        }


        public ArticleManagerVM()
        {
            articleRepository = new();
            Articles = new();
            Articles = new(articleRepository.GetAll());
        }
    }
}
