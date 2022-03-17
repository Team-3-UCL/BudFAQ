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
    public class BrakeCaliperManagerVM
    {
        BrakeCaliperRepository brakeCaliperRepository;
        public BrakeCaliper ChosenBrakeCaliper { get; set; }
        public ObservableCollection<BrakeCaliper> BrakeCalipers { get; set; }

        public void AddDefaultBrakeCaliper()
        {
            brakeCaliperRepository.Add("specify name", 0);
            BrakeCalipers.Add(brakeCaliperRepository.GetAll().Last());
            
        }

        public void DeleteSelectedBrakeCaliper()
        {
            brakeCaliperRepository.Remove(ChosenBrakeCaliper.BrakeCaliperID);
            BrakeCalipers.Remove(ChosenBrakeCaliper);

        }

        public void UpdateSelectedBrakeCaliper()
        {
            if(ChosenBrakeCaliper != null)
            {
                brakeCaliperRepository.Update(ChosenBrakeCaliper.BrakeCaliperID, ChosenBrakeCaliper);
            }
            BrakeCalipers = new(brakeCaliperRepository.GetAll());
        }


        public BrakeCaliperManagerVM()
        {
            brakeCaliperRepository = new();
            BrakeCalipers = new();
            BrakeCalipers = new(brakeCaliperRepository.GetAll());
        }
    }
}
