﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TransferEmployeesToEmployeeRequestWindowsApplication.Models
{
    public partial class TblCompilationType
    {
        public TblCompilationType()
        {
            TblUserCompilations = new HashSet<TblUserCompilation>();
        }

        public int Id { get; set; }
        public string CompilationType { get; set; }

        public virtual ICollection<TblUserCompilation> TblUserCompilations { get; set; }
    }
}
