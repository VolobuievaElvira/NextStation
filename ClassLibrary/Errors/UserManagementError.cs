public enum UserManagementErrorReason
{
    UserDoesNotExists
}

public class UserManagementError : Exception
{
    public UserManagementErrorReason Reason;

    public UserManagementError(UserManagementErrorReason reason, string message) : base(message)
    {
        Reason = reason;
    }
}