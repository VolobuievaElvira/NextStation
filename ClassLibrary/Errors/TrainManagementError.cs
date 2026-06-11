public enum TrainManagementErrorReason
{
    TrainDoesNotExists,
    CarDoesNotExists,
}

public class TrainManagementError : Exception
{
    public TrainManagementErrorReason Reason;

    public TrainManagementError(TrainManagementErrorReason reason, string message) : base(message)
    {
        Reason = reason;
    }
}