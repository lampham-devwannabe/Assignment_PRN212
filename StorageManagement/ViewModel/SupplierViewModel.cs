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
    public class SupplierViewModel : BaseViewModel
    {
        private ObservableCollection<Supplier> _SupplierList;
        public ObservableCollection<Supplier> SupplierList { get => _SupplierList; set { _SupplierList = value; OnPropertyChanged(); } }
        private Supplier _SelectedItem;
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public Supplier SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    Phone = SelectedItem.Phone;
                    Email = SelectedItem.Email;
                    Address = SelectedItem.Address;
                    MoreInfo = SelectedItem.MoreInfo;
                    ContractDate = SelectedItem.ContractDate;
                }
            }
        }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }
        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }
        public SupplierViewModel()
        {
            SupplierList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Suppliers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
               (p) =>
               {
                   Supplier Supplier = new Supplier() { DisplayName = DisplayName, Phone = Phone, Address = Address, Email = Email, ContractDate = ContractDate, MoreInfo = MoreInfo };
                   DataProvider.Ins.DB.Suppliers.Add(Supplier);
                   DataProvider.Ins.DB.SaveChanges();
                   SupplierList.Add(Supplier);
               });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) return false;
                var displayList = DataProvider.Ins.DB.Suppliers.Where(p => p.Id == SelectedItem.Id);
                if (displayList != null || displayList.Count() != 0) return true;
                return false;
            },
               (p) =>
               {
                   Supplier sup = DataProvider.Ins.DB.Suppliers.Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
                   sup.DisplayName = DisplayName;
                   sup.Phone = Phone;
                   sup.Address = Address;
                   sup.Email = Email;
                   sup.ContractDate = ContractDate;
                   sup.MoreInfo = MoreInfo;
                   DataProvider.Ins.DB.Suppliers.Update(sup);
                   DataProvider.Ins.DB.SaveChanges();
                   SelectedItem.DisplayName = DisplayName;
               });
        }
    }
}
