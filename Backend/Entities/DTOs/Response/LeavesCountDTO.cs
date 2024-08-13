namespace Entities.DTOs;

public class LeavesCountDTO
{
    public int TotalRequestsCount { get; init; }

    public int PendingRequestsCount { get; init; }

    public int ApprovedRequestsCount { get; init; }

    public int DeclinedRequestCount { get; init; }

    public int LeavesRemainingCount { get; init; }

    public int SickLeavesCount { get; init; }
}
