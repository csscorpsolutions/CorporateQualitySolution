using System;
using System.Collections.Generic;

#nullable disable

namespace CorporateQualitySolution.Models.DB
{
    public partial class TblProjectAccountMapping
    {
        public Guid? Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid AccountId { get; set; }
        public Guid BusinessUnitId { get; set; }
        public Guid LocationId { get; set; }

        public virtual TblAccountMaster Account { get; set; }
        public virtual TblBusinessUnitMaster BusinessUnit { get; set; }
        public virtual TblLocationMaster Location { get; set; }
        public virtual TblProjectMaster Project { get; set; }
    }
}
