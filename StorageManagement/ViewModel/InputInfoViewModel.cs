using Microsoft.EntityFrameworkCore;
using StorageManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StorageManagement.ViewModel
{
    public class InputInfoViewModel : BaseViewModel
    {
        private ObservableCollection<InputInfo> _List;
        public ObservableCollection<InputInfo> List
        {
            get => _List;
            set { _List = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Models.Object> _ObjectsList;
        public ObservableCollection<Models.Object> ObjectsList
        {
            get => _ObjectsList;
            set { _ObjectsList = value; OnPropertyChanged(); }
        }
        private InputInfo _SelectedItem;
        public InputInfo SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (_SelectedItem != null)
                {
                    IdObject = _SelectedItem.IdObject;
                    ObjectDisplayName = _SelectedItem.IdObjectNavigation.DisplayName;
                    Count = _SelectedItem.Count ?? 0;
                    PriceInput = _SelectedItem.InputPrice ?? 0;
                    PriceOutput = _SelectedItem.OutputPrice ?? 0;
                    Status = _SelectedItem.Status;
                }
            }
        }

        private string _IdObject;
        public string IdObject
        {
            get => _IdObject;
            set { _IdObject = value; OnPropertyChanged(); }
        }

        private string _ObjectDisplayName;
        public string ObjectDisplayName
        {
            get => _ObjectDisplayName;
            set { _ObjectDisplayName = value; OnPropertyChanged(); }
        }


        private int _Count;
        public int Count
        {
            get => _Count;
            set { _Count = value; OnPropertyChanged(); }
        }

        private double _PriceInput;
        public double PriceInput
        {
            get => _PriceInput;
            set { _PriceInput = value; OnPropertyChanged(); }
        }

        private double _PriceOutput;
        public double PriceOutput
        {
            get => _PriceOutput;
            set { _PriceOutput = value; OnPropertyChanged(); }
        }

        private string _Status;
        public string Status
        {
            get => _Status;
            set { _Status = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public InputInfoViewModel()
        {
            List = new ObservableCollection<InputInfo>(DataProvider.Ins.DB.InputInfos.Include(p => p.IdInputNavigation).ToList());
            ObjectsList = new ObservableCollection<Models.Object>(DataProvider.Ins.DB.Objects.ToList());
            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) => { Add(); });
            EditCommand = new RelayCommand<object>((p) => { return SelectedItem != null; }, (p) => { Edit(); });
            DeleteCommand = new RelayCommand<object>((p) => { return SelectedItem != null; }, (p) => { Delete(); });
        }

        private void Add()
        {
            var newInput = new Input
            {
                Id = (DataProvider.Ins.DB.Inputs.Count() + 1).ToString(),
                DateInput = DateTime.Now,
            };

            var newInputInfo = new InputInfo
            {
                Id = (DataProvider.Ins.DB.InputInfos.Count() + 1).ToString(),
                IdObject = IdObject,
                IdInput = newInput.Id,
                Count = Count,
                InputPrice = PriceInput,
                OutputPrice = PriceOutput,
                Status = Status
            };

            DataProvider.Ins.DB.Inputs.Add(newInput);
            DataProvider.Ins.DB.InputInfos.Add(newInputInfo);
            DataProvider.Ins.DB.SaveChanges();

            List.Add(newInputInfo);
        }

        private void Edit()
        {
            var inputInfo = DataProvider.Ins.DB.InputInfos.FirstOrDefault(x => x.Id == SelectedItem.Id);
            if (inputInfo != null)
            {
                var input = DataProvider.Ins.DB.Inputs.FirstOrDefault(x => x.Id == inputInfo.IdInput);
                if (input != null)
                {
                    input.DateInput = DateTime.Now;
                }
                inputInfo.IdObject = IdObject;
                inputInfo.Count = Count;
                inputInfo.InputPrice = PriceInput;
                inputInfo.OutputPrice = PriceOutput;
                inputInfo.Status = Status;
                DataProvider.Ins.DB.SaveChanges();
                var index = List.IndexOf(SelectedItem);
                List[index] = inputInfo;
            }
        }

        private void Delete()
        {
            var inputInfo = DataProvider.Ins.DB.InputInfos.FirstOrDefault(x => x.Id == SelectedItem.Id);
            if (inputInfo != null)
            {
                var input = DataProvider.Ins.DB.Inputs.FirstOrDefault(x => x.Id == inputInfo.IdInput);
                if (input != null)
                {
                    DataProvider.Ins.DB.Inputs.Remove(input);
                }

                DataProvider.Ins.DB.InputInfos.Remove(inputInfo);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(inputInfo);
            }
        }
    }
}
