using MediatR;

namespace MeetingRoom.CrossCutting.Notification
{
    public class Notification : INotification
    {
        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }
}
