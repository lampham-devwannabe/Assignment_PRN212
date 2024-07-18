using StorageManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace StorageManagement.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> _CustomerList;
        public ObservableCollection<Customer> CustomerList { get => _CustomerList; set { _CustomerList = value; OnPropertyChanged(); } }
        private Customer _SelectedItem;
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public Customer SelectedItem
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
        public CustomerViewModel()
        {
            CustomerList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            },
               (p) =>
               {
                   Customer cus = new Customer() { DisplayName = DisplayName, Phone = Phone, Address = Address, Email = Email, ContractDate = ContractDate, MoreInfo = MoreInfo };
                   DataProvider.Ins.DB.Customers.Add(cus);
                   DataProvider.Ins.DB.SaveChanges();
                   CustomerList.Add(cus);
               });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) return false;
                var displayList = DataProvider.Ins.DB.Customers.Where(p => p.Id == SelectedItem.Id);
                if (displayList != null || displayList.Count() != 0) return true;
                return false;
            },
               (p) =>
               {
                   Customer cus = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
                   cus.DisplayName = DisplayName;
                   cus.Phone = Phone;
                   cus.Address = Address;
                   cus.Email = Email;
                   cus.ContractDate = ContractDate;
                   cus.MoreInfo = MoreInfo;
                   DataProvider.Ins.DB.Customers.Update(cus);
                   DataProvider.Ins.DB.SaveChanges();
                   SelectedItem.DisplayName = DisplayName;
               });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Customer = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                if (Customer != null)
                {
                    var outputInfo = DataProvider.Ins.DB.OutputInfos
                                          .Where(x => x.IdCustomer == Customer.Id)
                                          .ToList();

                    if (outputInfo != null && outputInfo.Count > 0)
                    {
                        foreach (var output in outputInfo)
                        {
                            DataProvider.Ins.DB.Remove(output);
                        }
                    }

                    DataProvider.Ins.DB.Customers.Remove(Customer);
                    DataProvider.Ins.DB.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
                List.Remove(SelectedItem);
            });
        }
    }
}
