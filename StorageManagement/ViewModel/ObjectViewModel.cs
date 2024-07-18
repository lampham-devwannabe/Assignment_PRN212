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
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Models.Object> _ObjectList;
        public ObservableCollection<Models.Object> ObjectList { get => _ObjectList; set { _ObjectList = value; OnPropertyChanged(); } }
        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }
        private ObservableCollection<Supplier> _Suplier;
        public ObservableCollection<Supplier> SupplierList { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }
        private Models.Object _SelectedItem;
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private Unit _SelectedUnit;
        public Unit SelectedUnit
        {
            get => _SelectedUnit;
            set
            {
                _SelectedUnit = value;
                OnPropertyChanged();
            }
        }
        private Supplier _SelectedSupplier;
        public Supplier SelectedSupplier
        {
            get => _SelectedSupplier;
            set
            {
                _SelectedSupplier = value;
                OnPropertyChanged();
            }
        }
        public Models.Object SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    QRCode = SelectedItem.Qrcode;
                    BarCode = SelectedItem.BarCode;
                    SelectedUnit = SelectedItem.IdUnitNavigation;
                    SelectedSupplier = SelectedItem.IdSupplierNavigation;
                }
            }
        }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _QRCode;
        public string QRCode { get => _QRCode; set { _QRCode = value; OnPropertyChanged(); } }
        private string _BarCode;
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }
        public ObjectViewModel()
        {
            ObjectList = new ObservableCollection<Models.Object>(DataProvider.Ins.DB.Objects);
            Unit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            SupplierList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Suppliers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedSupplier == null || SelectedUnit == null) return false;
                return true;
            },
               (p) =>
               {
                   var obj = new Models.Object() { DisplayName = DisplayName, BarCode = BarCode, Qrcode = QRCode, IdSupplier = SelectedSupplier.Id, IdUnit = SelectedUnit.Id, Id = Guid.NewGuid().ToString() };
                   DataProvider.Ins.DB.Objects.Add(obj);
                   DataProvider.Ins.DB.SaveChanges();
                   ObjectList.Add(obj);
               });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedSupplier == null || SelectedUnit == null)
                    return false;
                var displayList = DataProvider.Ins.DB.Objects.Where(p => p.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0) return true;
                return false;
            },
               (p) =>
               {
                   var obj = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                   obj.DisplayName = DisplayName;
                   obj.BarCode = BarCode;
                   obj.Qrcode = QRCode;
                   obj.IdSupplier = SelectedSupplier.Id;
                   obj.IdUnit = SelectedUnit.Id;
                   DataProvider.Ins.DB.Update(obj);
                   DataProvider.Ins.DB.SaveChanges();
                   SelectedItem.DisplayName = DisplayName;
               });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Object = DataProvider.Ins.DB.Objects.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                var input = DataProvider.Ins.DB.InputInfos.Where(x => x.IdObject == Object.Id).SingleOrDefault();
                var output = DataProvider.Ins.DB.OutputInfos.Where(x => x.IdObject == Object.Id).SingleOrDefault();

                if (input != null)
                    DataProvider.Ins.DB.InputInfos.Remove(input);
                if (output != null)
                    DataProvider.Ins.DB.OutputInfos.Remove(output);

                DataProvider.Ins.DB.Objects.Remove(Object);
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DisplayName = DisplayName;
            });
        }
    }
}
