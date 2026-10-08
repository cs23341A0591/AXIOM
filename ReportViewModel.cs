using AcxiomCRM.Models;

namespace AcxiomCRM.ViewModels
{
    public class ReportContainerViewModel
    {
        public string ReportType { get; set; } = "Pipeline";
        public string? Search { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        // Report Data Lists
        public List<CustomerReportItem> CustomerItems { get; set; } = new();
        public List<LeadReportItem> LeadItems { get; set; } = new();
        public List<FollowUpReportItem> FollowUpItems { get; set; } = new();
        public List<OpportunityReportItem> OpportunityItems { get; set; } = new();
        public List<PipelineReportItem> PipelineItems { get; set; } = new();
        public List<ConversionReportItem> ConversionItems { get; set; } = new();
        public List<UserActivityReportItem> UserActivityItems { get; set; } = new();
        public List<AuditLog> AuditItems { get; set; } = new();

        // Summary Totals
        public decimal TotalPipelineValue { get; set; }
        public decimal TotalWeightedPipelineValue { get; set; }
        public int ConvertedLeadsCount { get; set; }
        public int UnconvertedLeadsCount { get; set; }
        public double ConversionRatePercentage { get; set; }
    }

    public class CustomerReportItem
    {
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    public class LeadReportItem
    {
        public string LeadCode { get; set; } = string.Empty;
        public string LeadName { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal ExpectedValue { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public bool IsConverted { get; set; }
        public string? ConvertedCustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class FollowUpReportItem
    {
        public int FollowUpId { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public string FollowUpType { get; set; } = string.Empty;
        public DateTime FollowUpDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public bool IsOverdue { get; set; }
        public string? Remarks { get; set; }
    }

    public class OpportunityReportItem
    {
        public string OpportunityName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Stage { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int Probability { get; set; }
        public decimal WeightedAmount => Amount * Probability / 100m;
        public DateTime ExpectedCloseDate { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class PipelineReportItem
    {
        public string Stage { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal WeightedAmount { get; set; }
    }

    public class ConversionReportItem
    {
        public string MonthYear { get; set; } = string.Empty;
        public int TotalLeads { get; set; }
        public int ConvertedLeads { get; set; }
        public decimal ConversionRate => TotalLeads > 0 ? (decimal)ConvertedLeads / TotalLeads * 100m : 0m;
        public decimal ConvertedValue { get; set; }
    }

    public class UserActivityReportItem
    {
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int TotalCustomersAssigned { get; set; }
        public int TotalLeadsAssigned { get; set; }
        public int TotalOpportunitiesAssigned { get; set; }
        public int TotalFollowUpsAssigned { get; set; }
        public int TotalActivitiesCount { get; set; }
    }
}
