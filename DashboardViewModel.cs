using AcxiomCRM.Models;

namespace AcxiomCRM.ViewModels
{
    public class DashboardViewModel
    {
        public string DateFilter { get; set; } = "ThisMonth";
        public DateTime? CustomStartDate { get; set; }
        public DateTime? CustomEndDate { get; set; }
        public string UserRole { get; set; } = string.Empty;

        // KPI Cards
        public int TotalCustomers { get; set; }
        public int TotalLeads { get; set; }
        public int OpenLeads { get; set; }
        public int TotalOpportunities { get; set; }
        public int OpenOpportunities { get; set; }
        public int WonOpportunities { get; set; }
        public int LostOpportunities { get; set; }
        public decimal TotalPipelineValue { get; set; }

        // Chart Data - Lead Status
        public List<string> LeadStatusLabels { get; set; } = new();
        public List<int> LeadStatusCounts { get; set; } = new();

        // Chart Data - Opportunity Pipeline Stages
        public List<string> OpportunityStageLabels { get; set; } = new();
        public List<int> OpportunityStageCounts { get; set; } = new();
        public List<decimal> OpportunityStageValues { get; set; } = new();

        // Chart Data - Monthly Sales Totals
        public List<string> MonthlySalesLabels { get; set; } = new();
        public List<decimal> MonthlySalesValues { get; set; } = new();

        // Role Specific Details
        public List<FollowUp> UpcomingFollowUps { get; set; } = new();
        public List<FollowUp> OverdueFollowUps { get; set; } = new();
        public List<Opportunity> RecentOpportunities { get; set; } = new();
        public List<Activity> RecentActivities { get; set; } = new();

        // Admin statistics
        public int TotalUsersCount { get; set; }
        public int ActiveUsersCount { get; set; }
        public int TotalAuditLogsCount { get; set; }
    }
}
