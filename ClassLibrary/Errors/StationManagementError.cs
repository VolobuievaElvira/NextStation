public enum StationManagementErrorReason
{
    PlatformDoesNotExist,
    PlatformAlreadyExists,
    OverlapOccured,
    TimeIntervalDoesNotExist
}

public class StationManagementError : Exception
{
    public StationManagementErrorReason Reason;

    public StationManagementError(StationManagementErrorReason reason, string message) : base(message)
    {
        Reason = reason;
    }
}