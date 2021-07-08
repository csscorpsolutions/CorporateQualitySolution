using System;
using System.Collections.Generic;

#nullable disable

namespace CorporateQualitySolution.Models.DB
{
    public partial class TblBusinessUnitMaster
    {
        public TblBusinessUnitMaster()
        {
            TblAccountBusinessUnitMappings = new HashSet<TblAccountBusinessUnitMapping>();
        }

        public Guid BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }
        public string BusinessUnitShortName { get; set; }
        public bool? Status { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TblAccountBusinessUnitMapping> TblAccountBusinessUnitMappings { get; set; }
    }
}
