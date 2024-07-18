using Azure.Core;
using StorageManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StorageManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Remaining> _remainList;
        public ObservableCollection<Remaining> RemainList { get => _remainList; set { _remainList = value; OnPropertyChanged(); } }
        public bool isLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    isLoaded = true;
                    if (p == null) return;
                    p.Hide();
                    LoginWindow log = new LoginWindow();
                    log.ShowDialog();
                    if (log.DataContext == null) return;
                    var loginVM = log.DataContext as LoginViewModel;
                    if (loginVM.IsLogin)
                    {
                        p.Show();
                        loadRemain();
                    }
                    else
                    {
                        p.Close();
                    }
                });
            UnitCommand = new RelayCommand<object>((p) => { return true; },
               (p) =>
               {
                   UnitWindow unit = new UnitWindow();
                   unit.ShowDialog();
               });
            SupplierCommand = new RelayCommand<object>((p) => { return true; },
               (p) =>
               {
                   SupplierWindow sup = new SupplierWindow();
                   sup.ShowDialog();
               });
            CustomerCommand = new RelayCommand<object>((p) => { return true; },
               (p) =>
               {
                   CustomerWindow cus = new CustomerWindow();
                   cus.ShowDialog();
               });
            ObjectCommand = new RelayCommand<object>((p) => { return true; },
              (p) =>
              {
                  ObjectWindow obj = new ObjectWindow();
                  obj.ShowDialog();
              });
            UserCommand = new RelayCommand<object>((p) => { return true; },
              (p) =>
              {
                  UserWindow user = new UserWindow();
                  user.ShowDialog();
              });
            InputCommand = new RelayCommand<object>((p) => { return true; },
              (p) =>
              {
                  InputWindow input = new InputWindow();
                  input.ShowDialog();
              });
            OutputCommand = new RelayCommand<object>((p) => { return true; },
              (p) =>
              {
                  OutputWindow output = new OutputWindow();
                  output.ShowDialog();
              });
        }
        void loadRemain()
        {
            RemainList = new ObservableCollection<Remaining>();
            var objList = DataProvider.Ins.DB.Objects.ToList();
            int no = 1;
            foreach (var item in objList)
            {
                var inputList = DataProvider.Ins.DB.InputInfos.Where(p => p.IdObject == item.Id);
                var outputList = DataProvider.Ins.DB.OutputInfos.Where(p => p.IdObject == item.Id);
                int sumInput = 0; 
                int sumOutput = 0;
                if (inputList != null && inputList.Count() > 0)
                {
                    sumInput = (int)inputList.Sum(p => p.Count);
                }
                if (outputList != null && outputList.Count() > 0)
                {
                    sumOutput = (int)outputList.Sum(p => p.Count);
                }
                Remaining rem = new Remaining();
                rem.No = no;
                rem.Count = sumInput - sumOutput;
                rem.Object = item;
                RemainList.Add(rem);
                no++;
            }
        }
    }
}
