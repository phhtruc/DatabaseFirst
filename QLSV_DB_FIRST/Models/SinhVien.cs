using System;
using System.Collections.Generic;

namespace QLSV_DB_FIRST.Models;

public partial class SinhVien
{
    public int Id { get; set; }

    public string TenSinhVien { get; set; } = null!;

    public int Age { get; set; }

    public int LopId { get; set; }

    public virtual Lop Lop { get; set; } = null!;
}
