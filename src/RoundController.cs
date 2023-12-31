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
    public static int CARDS_IN_HAND = 5;

    [Export]
    public static AudioStreamPlayer turnSfx;

    public enum RoundState
    {
        startGame,
        startGameDialogue,
        playersTurn,
        enemyTurn,
        selectACardToSteal,
        offendedDialogue,
        roundEndWinnerDialogue,
        RoundEndOffendedDialogue,
    }

    public static int currentRound = 1;

    public static RoundState currentRoundState = RoundState.playersTurn;

    public static void Reset()
    {
        currentRound = 0;
        currentRoundState = RoundState.startGame;
    }

    public bool CanPlayerPlay()
    {
        return currentRoundState == RoundState.playersTurn;
    }

    public override void _Ready()
    {
        instance = this;
        Reset();
    }

    public override void _Process(double delta)
    {
        UpdateState();
        SetCurrentInstruction();
    }

    public void SetCurrentInstruction()
    {
        if (currentRoundState == RoundState.selectACardToSteal)
        {
            CurrentInstructionManager.currentInstruction = "Select a card to steal";
        }
        else if (currentRoundState == RoundState.playersTurn)
        {
            CurrentInstructionManager.currentInstruction = "Click a card from your hand to play it";
        }
        else
        {
            CurrentInstructionManager.currentInstruction = "";
        }
    }

    public void UpdateState()
    {
        if (currentRoundState == RoundState.offendedDialogue && DialogueState.IsFinished())
        {
            RoundController.PlayComputers();
        }
        if (currentRoundState == RoundState.selectACardToSteal) { }
        if (currentRoundState == RoundState.roundEndWinnerDialogue && DialogueState.IsFinished())
        {
            currentRoundState = RoundState.RoundEndOffendedDialogue;
            DialogueState.SetDialogue(AngerBasedDialogue.GetDialog());
        }
        if (currentRoundState == RoundState.RoundEndOffendedDialogue && DialogueState.IsFinished())
        {
            StartNewRound();
        }
        if (currentRoundState == RoundState.startGame)
        {
            currentRoundState = RoundState.startGameDialogue;
            DialogueState.SetDialogue((GetStartGameDialogue()));
        }
        if (currentRoundState == RoundState.startGameDialogue && DialogueState.IsFinished())
        {
            StartNewRound();
        }
    }

    public static Dialogue GetStartGameDialogue()
    {
        return new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Elf, "Ah, and Human arrives."),
                new DialogueLine(
                    Dialogue.players.Golem,
                    "Hello, Human. You Brought Your Wife’s Jam!"
                ),
                new DialogueLine(Dialogue.players.Dwarf, "He always brings the jam, jus’ like us."),
                new DialogueLine(
                    Dialogue.players.Elf,
                    "As if he doesn’t return home with enough each night. Human, are you intending to make this evening enjoyable or strenuous?"
                ),
                new DialogueLine(
                    Dialogue.players.Dwarf,
                    "You keep askin’ that question like yer gonna get a different answer."
                ),
                new DialogueLine(
                    Dialogue.players.Golem,
                    "Human Wins A Lot. I Never Get To Try His Jam."
                ),
                new DialogueLine(Dialogue.players.Dwarf, "Then let’s change that."),
                new DialogueLine(
                    Dialogue.players.Elf,
                    "For once, I agree with you. Play nice, Human, would you?"
                ),
                new DialogueLine(Dialogue.players.Golem, "I Play Nicely!"),
                new DialogueLine(Dialogue.players.Dwarf, "’S an expression."),
                new DialogueLine(
                    Dialogue.players.Elf,
                    "Alright then, gentlemen. Good luck. You’ll need it."
                ),
                new DialogueLine(Dialogue.players.Dwarf, "Jus’ deal the cards. Winner takes all."),
                new DialogueLine(Dialogue.players.Golem, "All The Jam! :D"),
            }
        );
    }

    public static RoundController instance;

    public void StartNewRound()
    {
        Random random = new Random(DateTime.Now.Millisecond);
        foreach (PlayerState computer in GetAllPlayers())
        {
            computer.cardsLaidDown = new Array<CardConfig>();
            computer.cardsInHand = new Array<CardConfig>();
            for (int i = 0; i < CARDS_IN_HAND; i++)
            {
                computer.cardsInHand.Add(cardList.cards[random.Next(cardList.cards.Count)]);
            }
            computer.RefreshVisuals();
        }
        currentRound += 1;
        currentRoundState = RoundState.playersTurn;
    }

    public static void RefreshAllVisuals()
    {
        foreach (PlayerState playerState in RoundController.instance.GetAllPlayers())
        {
            playerState.RefreshVisuals();
        }
    }

    public static void PlayComputers()
    {
        currentRoundState = RoundState.enemyTurn;

        Random random = new Random(DateTime.Now.Millisecond);
        int index = 1;

        foreach (PlayerState computer in instance.computers)
        {
            Timer nextTimer = new Timer();
            nextTimer.WaitTime = 1.0f * index;
            nextTimer.OneShot = true;
            nextTimer.Timeout += () =>
            {
                int cardIndex = computer.cardsInHand.Count;
                CardConfig computerCardToPlay = null;
                foreach (CardConfig cardConfig in computer.cardsInHand)
                {
                    if (cardConfig.cardType == CardConfig.CardType.Jelly)
                    {
                        computerCardToPlay = cardConfig;
                    }
                }
                if (computerCardToPlay == null)
                {
                    computerCardToPlay = computer.cardsInHand[random.Next(cardIndex)];
                }
                computer.PlayCard(computerCardToPlay, true);
            };
            computer.AddChild(nextTimer);
            nextTimer.Start();
            index += 1;
        }
        Timer canPlayTimer = new Timer();
        canPlayTimer.WaitTime = 1.0f * (index) + 0.1f;
        canPlayTimer.OneShot = true;
        canPlayTimer.Timeout += () =>
        {
            currentRoundState = RoundState.playersTurn;

            if (RoundController.instance.player.cardsInHand.Count == 0)
            {
                PlayRoundEndDialogue();
            }
            else
            {
                RoundController.RotateHands();
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

    public static void RotateHands()
    {
        NotificationManager.ShowNotification("Passed hands clockwise");
        List<PlayerState> players = RoundController.instance.GetAllPlayers();

        Array<CardConfig> firstHand = new Array<CardConfig>(players[0].cardsInHand);
        players[0].cardsInHand = new Array<CardConfig>(players[1].cardsInHand);
        players[1].cardsInHand = new Array<CardConfig>(players[2].cardsInHand);
        players[2].cardsInHand = new Array<CardConfig>(players[3].cardsInHand);
        players[3].cardsInHand = new Array<CardConfig>(firstHand);

        RefreshAllVisuals();
    }
}
