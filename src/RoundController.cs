using Godot;
using System;
using System.Collections.Generic;
using System.Collections;
using Godot.Collections;
using System.Data;

public partial class RoundController : Node
{
    [Export]
    public PlayerState player;

    [Export]
    public Array<PlayerState> computers;

    [Export]
    public CardListConfig cardList;
    public int CARDS_IN_HAND = 5;

    [Export]
    public static AudioStreamPlayer turnSfx;

    public enum RoundState
    {
        playersTurn,
        enemyTurn,
        offendedDialogue,
        roundEndWinnerDialogue,
        RoundEndOffendedDialogue,
    }

    public static RoundState currentRoundState = RoundState.playersTurn;

    public bool CanPlayerPlay()
    {
        return currentRoundState == RoundState.playersTurn;
    }

    public override void _Ready()
    {
        instance = this;
        StartNewRound();
    }

    public override void _Process(double delta)
    {
        UpdateState();
    }

    public void UpdateState()
    {
        GD.Print(currentRoundState);
        if (currentRoundState == RoundState.offendedDialogue && DialogueState.IsFinished())
        {
            currentRoundState = RoundState.enemyTurn;
            RoundController.PlayComputers();
        }
        if (currentRoundState == RoundState.roundEndWinnerDialogue && DialogueState.IsFinished())
        {
            currentRoundState = RoundState.playersTurn;
        }
    }

    public static RoundController instance;

    public void StartNewRound()
    {
        Random random = new Random(new System.DateTime().Millisecond);
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
        Random random = new Random(new System.DateTime().Millisecond);
        int index = 1;

        currentRoundState = RoundState.enemyTurn;

        foreach (PlayerState computer in instance.computers)
        {
            Timer nextTimer = new Timer();
            nextTimer.WaitTime = 1.0f * index;
            nextTimer.OneShot = true;
            nextTimer.Timeout += () =>
            {
                int cardIndex = computer.cardsInHand.Count;
                computer.PlayCard(computer.cardsInHand[random.Next(cardIndex)], true);
            };
            computer.AddChild(nextTimer);
            nextTimer.Start();
            index += 1;
        }
        Timer canPlayTimer = new Timer();
        canPlayTimer.WaitTime = 1.0f * (index - 1);
        canPlayTimer.OneShot = true;
        canPlayTimer.Timeout += () =>
        {
            currentRoundState = RoundState.playersTurn;

            if (RoundController.instance.player.cardsInHand.Count == 0)
            {
                PlayRoundEndDialogue();
            }
            turnSfx?.Play(0);
        };
        instance.computers[1].AddChild(canPlayTimer);
        canPlayTimer.Start();
    }

    public List<PlayerState> GetAllPlayers()
    {
        var players = new List<PlayerState>(computers);
        players.Add(player);
        return players;
    }

    public static void PlayRoundEndDialogue()
    {
        currentRoundState = RoundState.roundEndWinnerDialogue;
        Dialogue dialogue = WinnerDialogue.GetWinnerDialogue();
        DialogueState.SetDialogue(dialogue);
    }
}
