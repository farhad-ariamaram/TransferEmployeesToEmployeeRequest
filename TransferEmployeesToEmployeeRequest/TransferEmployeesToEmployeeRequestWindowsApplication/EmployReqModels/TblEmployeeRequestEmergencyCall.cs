﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TransferEmployeesToEmployeeRequestWindowsApplication.EmployReqModels
{
    public partial class TblEmployeeRequestEmergencyCall
    {
        public long FldEmployeeRequestEmergencyCallId { get; set; }
        public string FldEmployeeRequestEmergencyCallFirstName { get; set; }
        public string FldEmployeeRequestEmergencyCallLastName { get; set; }
        public string FldEmployeeRequestEmergencyCallRelative { get; set; }
        public string FldEmployeeRequestEmergencyCallPhoneNo { get; set; }
        public string FldEmployeeRequestEmergencyCallDescription { get; set; }
        public string FldEmployeeRequestEmployeeId { get; set; }

        public virtual TblEmployeeRequestEmployee FldEmployeeRequestEmployee { get; set; }
    }
}
