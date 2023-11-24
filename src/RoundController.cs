using Godot;
using System;
using System.Collections.Generic;
using System.Collections;
using Godot.Collections;

public partial class RoundController : Node
{
    [Export]
    public PlayerState player;

    [Export]
    public Array<PlayerState> computers;

    [Export]
    public CardListConfig cardList;
    public int CARDS_IN_HAND = 7;

    public override void _Ready()
    {
        instance = this;
        StartNewRound();
    }

    public static RoundController instance;

    public void StartNewRound()
    {
        var random = new Random();
        List<PlayerState> computersAndPlayer = new List<PlayerState>(computers);
        computersAndPlayer.Add(player);
        foreach (PlayerState computer in computersAndPlayer)
        {
            computer.cardsLaidDown = new Array<CardConfig>();
            computer.cardsInHand = new Array<CardConfig>();
            for (int i = 0; i < CARDS_IN_HAND; i++)
            {
                computer.cardsInHand.Add(cardList.cards[random.Next(cardList.cards.Count)]);
            }
            computer.RefreshVisuals();
        }
    }

    public static void PlayComputers()
    {
        Random random = new Random();

        foreach (PlayerState computer in instance.computers)
        {
            int cardIndex = computer.cardsInHand.Count;
            computer.PlayCard(computer.cardsInHand[random.Next(cardIndex)], true);
        }
    }
}
