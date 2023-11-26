using Godot;

public partial class NotificationManager : ColorRect
{
    float opacity = 0.0f;
    public static NotificationManager instance;

    public override void _Ready()
    {
        instance = this;
    }

    public static void ShowNotification(string notification)
    {
        instance.opacity = 2.0f;
        instance.GetChild<Label>(0).Text = notification;
    }

    public override void _Process(double delta)
    {
        opacity -= (float)delta;
        Modulate = new Color(1, 1, 1, Mathf.Max(0.0f, Mathf.Min(1.0f, opacity)));
    }
}
