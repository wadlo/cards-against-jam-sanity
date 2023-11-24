using Godot;
using Godot.Collections;
using System.Collections.Generic;

public partial class PlayerState : Node
{
    public Array<CardConfig> cardsLaidDown = new Array<CardConfig>();

    [Export]
    public Array<CardConfig> cardsInHand;

    // Each time the player makes a bad choice, friendship goes down. When a good choice is made, it goes up.
    public int timesOffended = 0;

    [Export]
    public int timesOffendedBeforeQuitting = 5;

    [Export]
    public Node2D handVisuals;

    [Export]
    public PackedScene cardPackedScene;

    public override void _Ready()
    {
        if (handVisuals != null)
            RefreshHandVisuals();
    }

    public void RefreshHandVisuals()
    {
        foreach (Node node in handVisuals.GetChildren())
        {
            node.QueueFree();
        }
        foreach (CardConfig card in cardsInHand)
        {
            Node2D instantiatedCard = (Node2D)cardPackedScene.Instantiate();
            handVisuals.AddChild(instantiatedCard);
            instantiatedCard.GetChild<Sprite2D>(0).Texture = card.cardImage;
        }
    }
}
