using Microsoft.EntityFrameworkCore;
using StorageManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StorageManagement.ViewModel
{
    public class OutputInfoViewModel : BaseViewModel
    {
        private ObservableCollection<OutputInfo> _List;
        public ObservableCollection<OutputInfo> List
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

        private ObservableCollection<Customer> _CustomerList;
        public ObservableCollection<Customer> CustomerList
        {
            get => _CustomerList;
            set { _CustomerList = value; OnPropertyChanged(); }
        }
        private OutputInfo _SelectedItem;
        public OutputInfo SelectedItem
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
                    IdCustomer = _SelectedItem.IdCustomer;
                    Count = _SelectedItem.Count ?? 0;
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

        private int _IdCustomer;
        public int IdCustomer { get => _IdCustomer; set { _IdCustomer = value; OnPropertyChanged(); } }

        private int _Count;
        public int Count
        {
            get => _Count;
            set { _Count = value; OnPropertyChanged(); }
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

        public OutputInfoViewModel()
        {
            List = new ObservableCollection<OutputInfo>(DataProvider.Ins.DB.OutputInfos.Include(p => p.IdNavigation).Include(p => p.IdCustomerNavigation).ToList());
            ObjectsList = new ObservableCollection<Models.Object>(DataProvider.Ins.DB.Objects.ToList());
            CustomerList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers.ToList());

            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) => { Add(); });
            EditCommand = new RelayCommand<object>((p) => { return SelectedItem != null; }, (p) => { Edit(); });
            DeleteCommand = new RelayCommand<object>((p) => { return SelectedItem != null; }, (p) => { Delete(); });
        }

        private void Add()
        {
            var inputList = DataProvider.Ins.DB.InputInfos.Where(p => p.IdObject == IdObject).ToList();
            var outputList = DataProvider.Ins.DB.OutputInfos.Where(p => p.IdObject == IdObject).ToList();

            if (Count > inputList.Sum(p => p.Count) - outputList.Sum(p => p.Count))
            {
                MessageBox.Show("Export quantity must not be larger than remaining.", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newOutput = new Output
            {
                Id = (DataProvider.Ins.DB.Outputs.Count() + 1).ToString(),
                DateOutput = DateTime.Now,
            };

            var newOutputInfo = new OutputInfo
            {
                Id = (DataProvider.Ins.DB.OutputInfos.Count() + 1).ToString(),
                IdObject = IdObject,
                IdOutputInfo = newOutput.Id,
                IdCustomer = IdCustomer,
                Count = Count,
                Status = Status
            };

            DataProvider.Ins.DB.Outputs.Add(newOutput);
            DataProvider.Ins.DB.OutputInfos.Add(newOutputInfo);
            DataProvider.Ins.DB.SaveChanges();

            List.Add(newOutputInfo);
        }

        private void Edit()
        {
            var inputList = DataProvider.Ins.DB.InputInfos.Where(p => p.IdObject == IdObject).ToList();
            var outputList = DataProvider.Ins.DB.OutputInfos.Where(p => p.IdObject == IdObject).ToList();

            if (Count > inputList.Sum(p => p.Count) - outputList.Sum(p => p.Count))
            {
                MessageBox.Show("Số lượng xuất không được nhiều hơn số lượng còn lại.");
                return;
            }
            var outputInfo = DataProvider.Ins.DB.OutputInfos.FirstOrDefault(x => x.Id == SelectedItem.Id);
            if (outputInfo != null)
            {
                var output = DataProvider.Ins.DB.Outputs.FirstOrDefault(x => x.Id == outputInfo.IdOutputInfo);
                if (output != null)
                {
                    output.DateOutput = DateTime.Now;
                }

                outputInfo.IdObject = IdObject;
                outputInfo.Count = Count;
                outputInfo.Status = Status;
                outputInfo.IdCustomer = IdCustomer;

                DataProvider.Ins.DB.SaveChanges();

                var index = List.IndexOf(SelectedItem);
                List[index] = outputInfo;
            }
        }

        private void Delete()
        {
            var outputInfo = DataProvider.Ins.DB.OutputInfos.FirstOrDefault(x => x.Id == SelectedItem.Id);
            if (outputInfo != null)
            {
                var output = DataProvider.Ins.DB.Outputs.FirstOrDefault(x => x.Id == outputInfo.IdOutputInfo);
                if (output != null)
                {
                    DataProvider.Ins.DB.Outputs.Remove(output);
                }

                DataProvider.Ins.DB.OutputInfos.Remove(outputInfo);
                DataProvider.Ins.DB.SaveChanges();

                List.Remove(outputInfo);
            }
        }
    }
}
