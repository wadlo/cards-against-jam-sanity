using Godot;
using System;

public partial class CardComponent : Area2D
{
    private bool hovered = false;
    Vector2 startScale;
    float defaultYPos;

    CardConfig config;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        startScale = GlobalScale;
        defaultYPos = Position.Y;
    }

    public override void _MouseEnter()
    {
        hovered = true;
        ZIndex = 2;
        var tween = GetTree().CreateTween();
        tween.TweenProperty(
            this,
            "global_scale",
            new Vector2((startScale.X + 1.0f) / 2 * 1.3f, (startScale.Y + 1.0f) / 2 * 1.3f),
            0.1f
        );
        tween.TweenProperty(this, "position", new Vector2(Position.X, defaultYPos - 100), 0.1f);
    }

    public override void _MouseExit()
    {
        hovered = false;
        ZIndex = 1;
        var tween = GetTree().CreateTween();
        tween.TweenProperty(this, "global_scale", new Vector2(startScale.X, startScale.Y), 0.1f);
        tween.TweenProperty(this, "position", new Vector2(Position.X, defaultYPos), 0.1f);
    }

    public override void _Input(InputEvent @event)
    {
        if (
            hovered
            && @event is InputEventMouseButton
            && ((InputEventMouseButton)@event).ButtonIndex == MouseButton.Left
            && ((InputEventMouseButton)@event).IsPressed()
        )
        {
            GetParent().Call("clicked_card", config);
        }
    }
}
