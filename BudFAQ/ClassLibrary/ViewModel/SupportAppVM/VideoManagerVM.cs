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
    public class VideoManagerVM
    {
        VideoRepository videoRepository;
        public Video ChosenVideo { get; set; }
        public ObservableCollection<Video> Videos { get; set; }

        public List<BrakeCaliper> NonChosenBrakeCalipers
        {
            get
            {
                List<BrakeCaliper> result = new(); // nulstille
                BrakeCaliperRepository brakeCaliperRepository = new();
                foreach (BrakeCaliper brakeCaliper in brakeCaliperRepository.GetAll())
                {
                    if (!ChosenVideo.BrakeCalipers.Any(
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

        public void AddDefaultVideo()
        {
            videoRepository.Add("specify title", 0, "specify link");
            Videos.Add(videoRepository.GetAll().Last());
        }

        public void DeleteSelectedVideo()
        {
            videoRepository.Remove(ChosenVideo.VideoID);
            Videos.Remove(ChosenVideo);
        }

        public void UpdateSelectedVideo()
        {
            if(ChosenVideo != null)
            {
                videoRepository.Update(ChosenVideo.VideoID, ChosenVideo);
            }
            Videos = new(videoRepository.GetAll());
        }


        public VideoManagerVM()
        {
            videoRepository = new();
            Videos = new();
            Videos = new(videoRepository.GetAll());
        }
    }
}
