using System;
using System.Collections.Generic;

#nullable disable

namespace CorporateQualitySolution.Models.DB
{
    public partial class TblAccountMaster
    {
        public TblAccountMaster()
        {
            TblAccountBusinessUnitMappings = new HashSet<TblAccountBusinessUnitMapping>();
        }

        public Guid AccountId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string DisplayAccountName { get; set; }
        public bool? Status { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TblAccountBusinessUnitMapping> TblAccountBusinessUnitMappings { get; set; }
    }
}
