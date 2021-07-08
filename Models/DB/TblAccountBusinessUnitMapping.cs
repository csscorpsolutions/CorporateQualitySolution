using System;
using System.Collections.Generic;

#nullable disable

namespace CorporateQualitySolution.Models.DB
{
    public partial class TblAccountBusinessUnitMapping
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid BusinessUnitId { get; set; }

        public virtual TblAccountMaster Account { get; set; }
        public virtual TblBusinessUnitMaster BusinessUnit { get; set; }
    }
}
