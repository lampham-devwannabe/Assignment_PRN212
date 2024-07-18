using System;
using System.Collections.Generic;

namespace StorageManagement.Models;

public partial class Input
{
    public string Id { get; set; } = null!;

    public DateTime? DateInput { get; set; }

    public virtual ICollection<InputInfo> InputInfos { get; set; } = new List<InputInfo>();
}
