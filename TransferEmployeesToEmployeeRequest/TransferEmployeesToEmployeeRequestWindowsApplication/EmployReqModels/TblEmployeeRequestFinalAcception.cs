using System;
using System.Collections.Generic;

#nullable disable

namespace TransferEmployeesToEmployeeRequestWindowsApplication.EmployReqModels
{
    public partial class TblEmployeeRequestFinalAcception
    {
        public TblEmployeeRequestFinalAcception()
        {
            TblEmployeeRequestEmployees = new HashSet<TblEmployeeRequestEmployee>();
        }

        public int FldEmployeeRequestFinalAcceptionId { get; set; }
        public string FldEmployeeRequestFinalAcceptionStatus { get; set; }

        public virtual ICollection<TblEmployeeRequestEmployee> TblEmployeeRequestEmployees { get; set; }
    }
}
