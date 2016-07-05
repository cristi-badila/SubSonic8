namespace Subsonic8.Messages
{
    using Windows.ApplicationModel;

    public class SuspendStateMessage
    {
        public SuspendingOperation SuspendingOperation { get; }

        public SuspendStateMessage(SuspendingOperation suspendingSuspendingOperation)
        {
            SuspendingOperation = suspendingSuspendingOperation;
        }
    }
}