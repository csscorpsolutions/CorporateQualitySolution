using System;
using System.Collections.Generic;

#nullable disable

namespace CorporateQualitySolution.Models.DB
{
    public partial class TblLocationMaster
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
