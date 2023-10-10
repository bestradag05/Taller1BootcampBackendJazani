using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.Investments
{
    public class InvestmentSaveDto
    {
        public decimal AmountInvestd { get; set; }

        public int? Year { get; set; }

        public string? Description { get; set; }

        public string? AccountantCode { get; set; }

        public int DocumentId { get; set; }

        public int HolderId { get; set; }

        public int InvestmentConceptId { get; set; }

        public int InvestmentTypeId { get; set; }

        public int MeasureUnit { get; set; }

        public int MiningConcessionId { get; set; }

        public int PeriodType { get; set; }


    }
}
