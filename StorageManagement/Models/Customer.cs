using StorageManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace StorageManagement.Models;

public partial class Customer : BaseViewModel
{
    public int Id { get; set; }
    private string? _DisplayName;
    public string? DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
    private string? _Address;
    public string? Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
    private string? _Phone;
    public string? Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
    private string? _Email;
    public string? Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
    private string? _MoreInfo;
    public string? MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }
    private DateTime? _ContractDate;
    public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
