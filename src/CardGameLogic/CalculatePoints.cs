using System.Collections.Generic;

public class CalculatePoints
{
    public int Calculate(List<Card> cards)
    {
        int points = 0;
        bool hasBread = false;

        foreach (Card card in cards)
        {
            if (card is JamCard)
            {
                points += 3;
            }
            if (card is BreadCard)
            {
                if (hasBread)
                {
                    points += 3;
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
