using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Documents;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.InvestmentConcepts;
using Taller.Application.Admins.Dtos.InvestmentTypes;
using Taller.Application.Admins.Dtos.MeasureUnits;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Dtos.MiningConsessions;
using Taller.Application.Admins.Dtos.PeriodTypes;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public decimal AmountInvestd { get; set; }

        public int? Year { get; set; }

        public string? Description { get; set; }

        public string? AccountantCode { get; set; }

        public DocumentSimpleDto? Document { get; set; }

        public HolderSimpleDto? Holder { get; set; }

        public InvesmentConceptSimpleDto InvestmentConcept { get; set; }

        public InvestmentTypeSimpleDto InvestmentType{ get; set; }

        public MeasureUnitSimpleDto MeasureUnit {  get; set; }

        public MiningConsessionSimpleDto MiningConcession { get; set; }

        public PeriodTypeSimpleDto PeriodType { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
