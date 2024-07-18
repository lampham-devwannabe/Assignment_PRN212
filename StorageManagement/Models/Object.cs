using StorageManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace StorageManagement.Models;

public partial class Object : BaseViewModel
{
    private string _Id;
    public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
    private string? _DisplayName;
    public string? DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
    private int _IdUnit;
    public int IdUnit { get => _IdUnit; set { _IdUnit = value; OnPropertyChanged(); } }
    private int _IdSupplier;
    public int IdSupplier { get => _IdSupplier; set { _IdSupplier = value; OnPropertyChanged(); } }
    private string? _Qrcode;
    public string? Qrcode { get => _Qrcode; set { _Qrcode = value; OnPropertyChanged(); } }
    private string? _BarCode;
    public string? BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }
    private Supplier? _IdSupplierNavigation;
    public virtual Supplier? IdSupplierNavigation { get => _IdSupplierNavigation; set { _IdSupplierNavigation = value; OnPropertyChanged(); } }
    private Unit? _IdUnitNavigation;
    public virtual Unit? IdUnitNavigation { get => _IdUnitNavigation; set { _IdUnitNavigation = value; OnPropertyChanged(); } }
    public virtual ICollection<InputInfo>? InputInfos { get; set; } 
    public virtual ICollection<OutputInfo>? OutputInfos { get; set; } 
}

