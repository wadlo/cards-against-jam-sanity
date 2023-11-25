using Godot;
using System;
using System.Collections.Generic;

public partial class CardComponent : Area2D
{
    Vector2 startScale;
    Vector2 startGlobalPosition;
    float defaultYPos;

    public CardConfig config;
    float startRotation = -1.0f;
    bool hasSetStartRotation = false;

    public static HashSet<CardComponent> hoveredCards = new HashSet<CardComponent>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        startScale = GlobalScale;
        defaultYPos = Position.Y;
    }

    public static CardComponent GetClosestHoveredCardToMouse(Viewport viewport)
    {
        float bestSquareDist = float.MaxValue;
        CardComponent bestOption = null;
        foreach (CardComponent cardComponent in hoveredCards)
        {
            float currSquareDist = (
                viewport.GetMousePosition() - cardComponent.startGlobalPosition
            ).LengthSquared();
            if (currSquareDist < bestSquareDist)
            {
                bestSquareDist = currSquareDist;
                bestOption = cardComponent;
            }
        }
        return bestOption;
    }

    public override void _MouseEnter()
    {
        hoveredCards.Add(this);
    }

    public override void _MouseExit()
    {
        hoveredCards.Remove(this);
    }

    public bool IsMostHoveredCard()
    {
        return hoveredCards.Contains(this) && GetClosestHoveredCardToMouse(GetViewport()) == this;
    }

    public override void _Process(double delta)
    {
        if (!hasSetStartRotation)
        {
            hasSetStartRotation = true;
            startRotation = GlobalRotation;
            startGlobalPosition = GlobalPosition;
        }
        if (IsMostHoveredCard())
        {
            ZIndex = 100;

            var tween = GetTree().CreateTween();
            tween.TweenProperty(
                this,
                "global_scale",
                new Vector2((startScale.X + 0.7f) / 2 * 1.3f, (startScale.Y + 0.7f) / 2 * 1.3f),
                0.1f
            );
            tween.TweenProperty(this, "global_rotation", 0.0f, 0.1f);
            tween.TweenProperty(this, "position", new Vector2(Position.X, defaultYPos - 100), 0.1f);
        }
        else
        {
            var tween = GetTree().CreateTween();
            tween.TweenProperty(
                this,
                "global_scale",
                new Vector2(startScale.X, startScale.Y),
                0.1f
            );
            tween.TweenProperty(this, "global_rotation", startRotation, 0.1f);
            tween.TweenProperty(this, "position", new Vector2(Position.X, defaultYPos), 0.1f);
            ZIndex = (int)Mathf.Round(GlobalScale.X);
        }
    }

    public override void _ExitTree()
    {
        hoveredCards.Remove(this);
    }

    public override void _Input(InputEvent @event)
    {
        if (
            @event is InputEventMouseButton
            && ((InputEventMouseButton)@event).ButtonIndex == MouseButton.Left
            && ((InputEventMouseButton)@event).IsPressed()
            && IsMostHoveredCard()
        )
        {
            GetParent().Call("clicked_card", config);
        }
    }
}
