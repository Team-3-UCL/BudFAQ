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

        private Article _chosenArticle;

        public Article ChosenArticle
        {
            get { return _chosenArticle; }
            set { 
                _chosenArticle = value;
            }
        }

        public List<BrakeCaliper> NonChosenBrakeCalipers
        {
            get
            {
                List<BrakeCaliper> result = new(); // nulstille
                BrakeCaliperRepository brakeCaliperRepository = new();
                foreach (BrakeCaliper brakeCaliper in brakeCaliperRepository.GetAll())
                {
                    if (!ChosenArticle.BrakeCalipers.Any(
                        cal => cal.BrakeCaliperID == brakeCaliper.BrakeCaliperID
                        && cal.BudwegNumber == brakeCaliper.BudwegNumber
                        && cal.Name == brakeCaliper.Name))
                    {
                        result.Add(brakeCaliper);
                    }
                }
                return result;
            }
        }
        public ObservableCollection<Article> Articles { get; set; }

        public void AddDefaultArticle()
        {
            articleRepository.Add("specify name", "specify text");
            Articles.Add(articleRepository.GetAll().Last());
            
        }

        public void DeleteSelectedArticle()
        {
            articleRepository.Remove(ChosenArticle.ArticleID);
            Articles.Remove(ChosenArticle);

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
