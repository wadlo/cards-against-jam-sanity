using Godot;
using Godot.Collections;
using System.Collections.Generic;

public class PlayerState
{
    public List<Card> cardsLaidDown;
    public List<Card> cardsInHand;

    // Each time the player makes a bad choice, friendship goes down. When a good choice is made, it goes up.
    public int timesOffended = 0;

    [Export]
    public int timesOffendedBeforeQuitting = 5;
}
