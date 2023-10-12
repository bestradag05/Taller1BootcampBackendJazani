namespace Taller.Application.Admins.Dtos.Investments
{
    public class InvestmentFilterDto
    {
        public decimal AmountInvestd { get; set; } = default!;
        public string? AccountantCode { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
        public bool State { get; set; }
    }
}
 