using System.Collections.Generic;

public class CalculatePoints
{
    public int Calculate(List<CardConfig> cards)
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
}
