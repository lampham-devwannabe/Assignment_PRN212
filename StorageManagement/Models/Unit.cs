using StorageManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace StorageManagement.Models;

public partial class Unit : BaseViewModel
{
    public int Id { get; set; }
    private string? _DisplayName;
    public string? DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

    public virtual ICollection<Object> Objects { get; set; } = new List<Object>();
}
