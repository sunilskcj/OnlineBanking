using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class AdminDetail
{
    public int AdminId { get; set; }

    public string? AdminPassword { get; set; }
}
