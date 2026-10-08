namespace AcxiomCRM.Validation
{
    /// <summary>
    /// Enforces valid lead lifecycle transitions. Converted is set only via lead conversion.
    /// </summary>
    public static class LeadStatusTransition
    {
        public static readonly IReadOnlyCollection<string> AllStatuses =
            new[] { "New", "Contacted", "Qualified", "Unqualified", "Lost", "Converted" };

        private static readonly Dictionary<string, HashSet<string>> AllowedTransitions = new(StringComparer.OrdinalIgnoreCase)
        {
            ["New"] = new(StringComparer.OrdinalIgnoreCase) { "Contacted", "Qualified", "Unqualified", "Lost" },
            ["Contacted"] = new(StringComparer.OrdinalIgnoreCase) { "New", "Qualified", "Unqualified", "Lost" },
            ["Qualified"] = new(StringComparer.OrdinalIgnoreCase) { "Contacted", "Unqualified", "Lost" },
            ["Unqualified"] = new(StringComparer.OrdinalIgnoreCase) { "New", "Contacted", "Lost" },
            ["Lost"] = new(StringComparer.OrdinalIgnoreCase) { "New", "Contacted", "Qualified" },
            ["Converted"] = new(StringComparer.OrdinalIgnoreCase) { "Converted" }
        };

        public static bool IsValidTransition(string? fromStatus, string? toStatus, bool allowConversionTarget = false)
        {
            if (string.IsNullOrWhiteSpace(fromStatus) || string.IsNullOrWhiteSpace(toStatus))
            {
                return false;
            }

            if (fromStatus.Equals(toStatus, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (toStatus.Equals("Converted", StringComparison.OrdinalIgnoreCase) && !allowConversionTarget)
            {
                return false;
            }

            if (!AllowedTransitions.TryGetValue(fromStatus, out var allowed))
            {
                return false;
            }

            return allowed.Contains(toStatus);
        }

        public static void ValidateTransition(string fromStatus, string toStatus)
        {
            if (!IsValidTransition(fromStatus, toStatus))
            {
                throw new InvalidOperationException(
                    $"Invalid lead status transition from '{fromStatus}' to '{toStatus}'. Use Convert Lead to mark as Converted.");
            }
        }
    }
}
