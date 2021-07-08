using System;
using System.Collections.Generic;

#nullable disable

namespace CorporateQualitySolution.Models.DB
{
    public partial class TblProjectMaster
    {
        public Guid ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectDesc { get; set; }
        public bool? Status { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
