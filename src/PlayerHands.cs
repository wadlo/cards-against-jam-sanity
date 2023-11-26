using Godot;
using System;

public partial class PlayerHands : Node2D
{
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (RoundController.currentRoundState == RoundController.RoundState.playersTurn)
        {
            var tween = GetTree().CreateTween();
            tween.TweenProperty(this, "position", new Vector2(0, 0), 0.1f);
        }
        else
        {
            var tween = GetTree().CreateTween();
            tween.TweenProperty(this, "position", new Vector2(0, 350.0f), 0.1f);
        }
    }
}
