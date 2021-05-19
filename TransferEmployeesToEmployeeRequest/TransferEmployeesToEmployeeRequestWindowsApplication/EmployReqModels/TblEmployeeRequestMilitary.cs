﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TransferEmployeesToEmployeeRequestWindowsApplication.EmployReqModels
{
    public partial class TblEmployeeRequestMilitary
    {
        public TblEmployeeRequestMilitary()
        {
            TblEmployeeRequestUserMilitaries = new HashSet<TblEmployeeRequestUserMilitary>();
        }

        public int FldEmployeeRequestMilitaryId { get; set; }
        public string FldEmployeeRequestMilitaryMilitaryStatus { get; set; }

        public virtual ICollection<TblEmployeeRequestUserMilitary> TblEmployeeRequestUserMilitaries { get; set; }
    }
}
