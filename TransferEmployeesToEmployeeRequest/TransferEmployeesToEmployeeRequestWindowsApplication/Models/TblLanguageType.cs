﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TransferEmployeesToEmployeeRequestWindowsApplication.Models
{
    public partial class TblLanguageType
    {
        public TblLanguageType()
        {
            TblUserLanguages = new HashSet<TblUserLanguage>();
        }

        public int Id { get; set; }
        public string LanguageType { get; set; }

        public virtual ICollection<TblUserLanguage> TblUserLanguages { get; set; }
    }
}
