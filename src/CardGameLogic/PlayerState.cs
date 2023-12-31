using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class PlayerState : Node
{
    public Array<CardConfig> cardsLaidDown = new Array<CardConfig>();

    [Export]
    public string name;

    [Export]
    private AudioStreamPlayer playOnTalk;

    [Export]
    public Dialogue.players player;

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

    public Action visualsRefreshed = () => { };

    [Export]
    public bool isPlayer;

    public override void _Ready()
    {
        if (handVisuals != null)
            RefreshVisuals();
    }

    public void RefreshVisuals()
    {
        if (handVisuals != null)
        {
            foreach (Node node in handVisuals.GetChildren())
            {
                node.QueueFree();
            }
            foreach (CardConfig card in cardsInHand)
            {
                Node2D instantiatedCard = (Node2D)cardPackedScene.Instantiate();
                instantiatedCard.Set("config", card);
                handVisuals.AddChild(instantiatedCard);
                instantiatedCard.GetChild<Sprite2D>(0).Texture = card.cardImage;
            }
        }

        visualsRefreshed.Invoke();
    }

    public void OnStartTalking()
    {
        if (playOnTalk != null)
        {
            playOnTalk.Play();
        }
    }

    public void PlayCard(CardConfig clickedCard, bool isAutomatic = false)
    {
        GetNode<AudioStreamPlayer>("../../CardSFX").Play(0);
        cardsLaidDown.Add(clickedCard);
        cardsInHand.Remove(clickedCard);
        RefreshVisuals();
        if (isAutomatic == false)
        {
            if (clickedCard.cardType == CardConfig.CardType.Honey)
            {
                PickACardToSteal();
            }
            else
            {
                RoundController.PlayComputers();
            }
        }
    }

    public static void PickACardToSteal()
    {
        RoundController.currentRoundState = RoundController.RoundState.selectACardToSteal;
        if (RoundController.instance.player.cardsInHand.Count == RoundController.CARDS_IN_HAND - 1)
        {
            RoundController.currentRoundState = RoundController.RoundState.offendedDialogue;
            RoundController.RefreshAllVisuals();
            NotificationManager.ShowNotification("There are no cards to steal");
        }
        else
        {
            NotificationManager.ShowNotification("Select a card to steal");
        }
    }

    public static void PlayOffendedDialogue(Dialogue.players offendedPlayer, int offendedLevel)
    {
        RoundController.currentRoundState = RoundController.RoundState.offendedDialogue;

        Dialogue dialogue = OffendedDialogue.GetRandomDialogueForOffendedPlayer(
            offendedPlayer,
            offendedLevel
        );
        DialogueState.SetDialogue(dialogue);
    }
}
