using System;
using System.Collections.Generic;
using Godot.Collections;

public class CalculatePoints
{
    public static int Calculate(Array<CardConfig> cards)
    {
        int points = 0;
        bool hasBread = false;

        foreach (CardConfig card in cards)
        {
            if (card.cardType == CardConfig.CardType.Jelly)
            {
                points += 4;
            }
            if (card.cardType == CardConfig.CardType.Bread)
            {
                if (hasBread)
                {
                    points += 5;
                    hasBread = false;
                }
                else
                {
                    hasBread = true;
                }
            }
        }

        return points;
    }

    public static PlayerState GetWinner()
    {
        PlayerState currWinner = null;
        int winnerScore = int.MinValue;
        foreach (PlayerState playerState in RoundController.instance.GetAllPlayers())
        {
            var playerScore = Calculate(playerState.cardsLaidDown);
            if (playerScore > winnerScore)
            {
                winnerScore = playerScore;
                currWinner = playerState;
            }
        }

        return currWinner;
    }
}
