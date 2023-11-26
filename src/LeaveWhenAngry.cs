using Godot;
using System;

public partial class LeaveWhenAngry : Node2D
{
    [Export]
    public PlayerState playerState;

    [Export]
    public Node visuals;

    public override void _Process(double delta)
    {
        if (playerState.timesOffended >= 4 && visuals != null)
        {
            NotificationManager.ShowNotification(playerState.name + " has left the game.");
            visuals.QueueFree();
            RoundController.instance.computers.Remove(playerState);
        }
    }
}
