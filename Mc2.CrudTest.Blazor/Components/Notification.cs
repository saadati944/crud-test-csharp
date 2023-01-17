namespace Mc2.CrudTest.Blazor.Components;

public struct Notification
{
    public string Message { get; set; }
    public int Delay { get; set; }
    public NotificationType NotificationType { get; set; }
}
