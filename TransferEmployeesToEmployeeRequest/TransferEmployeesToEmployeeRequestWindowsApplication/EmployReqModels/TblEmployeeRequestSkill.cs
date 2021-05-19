﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TransferEmployeesToEmployeeRequestWindowsApplication.EmployReqModels
{
    public partial class TblEmployeeRequestSkill
    {
        public TblEmployeeRequestSkill()
        {
            TblEmployeeRequestUserSkills = new HashSet<TblEmployeeRequestUserSkill>();
        }

        public int FldEmployeeRequestSkillsId { get; set; }
        public string FldEmployeeRequestSkillsSkillTitle { get; set; }

        public virtual ICollection<TblEmployeeRequestUserSkill> TblEmployeeRequestUserSkills { get; set; }
    }
}
