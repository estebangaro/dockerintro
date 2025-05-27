using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Counter
{
    public int Id { get; set; }

    public int Count { get; set; }

    public DateTime Lastupdatedate { get; set; }

    public string Tag { get; set; } = null!;

    public DateTime Createdate { get; set; }
}
