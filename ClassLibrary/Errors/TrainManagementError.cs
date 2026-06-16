public enum TrainManagementErrorReason
{
    TrainDoesNotExists,
    CarDoesNotExists,
    InvalidCapacity,
    StationNotSelected,
    RouteStopDoesNotExists,
    CapacityLessOrEqualZero,
    CarIsAlreadyConnected,
    CarDoesNotConnected,
    NumberOfSeatsLessOrEqualZero,
    InvalidNumberOfSeats
}

public class TrainManagementError : Exception
{
    public TrainManagementErrorReason Reason;

    public TrainManagementError(TrainManagementErrorReason reason, string message) : base(message)
    {
        Reason = reason;
    }
}