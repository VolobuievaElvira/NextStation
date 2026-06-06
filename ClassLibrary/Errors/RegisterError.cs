public enum RegisterErrorReason
{
    PasswordLengthOutOfRange,
    PasswordsDontMatch,
    PasswordInsecure,
    EmailAlreadyRegistered
}

public class RegisterError : Exception
{
    public RegisterErrorReason Reason;

    public RegisterError(RegisterErrorReason reason, string message) : base(message)
    {
        Reason = reason;
    }
}