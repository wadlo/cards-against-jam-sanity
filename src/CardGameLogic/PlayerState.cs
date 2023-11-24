using Godot;
using Godot.Collections;
using System.Collections.Generic;

public partial class PlayerState : Node
{
    public List<Card> cardsLaidDown = new List<Card>();
    public List<Card> cardsInHand;

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
        // Give each player the same hand for now
        cardsInHand = new List<Card>();
        cardsInHand.Add(new BreadCard());
        cardsInHand.Add(new BreadCard());
        cardsInHand.Add(new JamCard());
        cardsInHand.Add(new JamCard());

        if (handVisuals != null)
            RefreshHandVisuals();
    }

    public void RefreshHandVisuals()
    {
        foreach (Node node in handVisuals.GetChildren())
        {
            node.QueueFree();
        }
        foreach (Card card in cardsInHand)
        {
            Node2D instantiatedCard = (Node2D)cardPackedScene.Instantiate();
            handVisuals.AddChild(instantiatedCard);
        }
    }
}
