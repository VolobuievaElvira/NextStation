public enum BookingErrorReason
{
    TicketIsAlreadyBooked
}

public class BookingError : Exception
{
    public BookingErrorReason Reason;

    public BookingError(BookingErrorReason reason, string message) : base(message)
    {
        Reason = reason;
    }
}