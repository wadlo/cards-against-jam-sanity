using System;
using System.Collections.Generic;

public class WinnerDialogue
{
    public Dialogue.players winner;
    public List<Dialogue> dialoguePossibilities;

    public WinnerDialogue(Dialogue.players _winner, List<Dialogue> _dialogue)
    {
        winner = _winner;
        dialoguePossibilities = _dialogue;
    }

    public static Dialogue GetWinnerDialogue()
    {
        var winner = CalculatePoints.GetWinner();
        if (winner.player == Dialogue.players.Dwarf)
            return GetRandomDwarfWinDialogue();
        if (winner.player == Dialogue.players.Elf)
            return GetRandomElfWinDialogue();
        if (winner.player == Dialogue.players.Golem)
            return GetRandomGolemWinDialogue();
        return GetRandomPlayerWinDialogue();
    }

    public static Dialogue GetRandomPlayerWinDialogue()
    {
        var option1 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(
                    Dialogue.players.Elf,
                    "Of course, why should we have expected any different?"
                ),
                new DialogueLine(Dialogue.players.Golem, "We Will Win The Next One!"),
                new DialogueLine(Dialogue.players.Dwarf, "We’ll sure try."),
            }
        );
        var option2 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Dwarf, "I’m sicka losing my wife’s jam to you."),
                new DialogueLine(Dialogue.players.Golem, "It Is Tiresome!"),
                new DialogueLine(Dialogue.players.Elf, "You don’t deserve to taste another bite."),
                new DialogueLine(Dialogue.players.Golem, "Agreed!"),
            }
        );
        var option3 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Golem, "Oh. This Is Going To Be Finished Fast."),
                new DialogueLine(Dialogue.players.Dwarf, "We’ll get the next one, won’t we?"),
                new DialogueLine(
                    Dialogue.players.Elf,
                    "Oh we will, even if I have to do it all myself."
                ),
                new DialogueLine(Dialogue.players.Dwarf, "Not a chance.")
            }
        );

        List<Dialogue> possibleDialogues = new List<Dialogue>() { option1, option2, option3 };
        Random random = new Random(DateTime.Now.Millisecond);
        return possibleDialogues[random.Next(possibleDialogues.Count)];
    }

    public static Dialogue GetRandomGolemWinDialogue()
    {
        var option1 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Golem, "I Won!"),
                new DialogueLine(Dialogue.players.Dwarf, "Mhm."),
                new DialogueLine(Dialogue.players.Golem, "This Is The Beginning Of My Success!"),
                new DialogueLine(
                    Dialogue.players.Elf,
                    "…cannot believe a hunk of clay did better than.."
                )
            }
        );
        var option2 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Golem, "Oh. I Did Not Expect That."),
                new DialogueLine(Dialogue.players.Dwarf, "You were playin’ to win, right?"),
                new DialogueLine(Dialogue.players.Golem, "I Do Not Know. I Got Distracted."),
                new DialogueLine(
                    Dialogue.players.Elf,
                    "You are a golem, designed for function and focus. What could have possibly distracted you?"
                ),
                new DialogueLine(Dialogue.players.Golem, "The Jam."),
                new DialogueLine(
                    Dialogue.players.Dwarf,
                    "Well, you gotta admit that’s pretty distractin’."
                ),
                new DialogueLine(Dialogue.players.Elf, "…"),
            }
        );
        var option3 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Golem, "That Was Fun!"),
                new DialogueLine(Dialogue.players.Elf, "Of course you thought it was."),
                new DialogueLine(Dialogue.players.Dwarf, "It’s a game."),
                new DialogueLine(Dialogue.players.Golem, "It Is A Fun Game! Again!")
            }
        );

        List<Dialogue> possibleDialogues = new List<Dialogue>() { option1, option2, option3 };
        Random random = new Random(DateTime.Now.Millisecond);
        return possibleDialogues[random.Next(possibleDialogues.Count)];
    }

    public static Dialogue GetRandomDwarfWinDialogue()
    {
        var option1 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Dwarf, "Heh. That shows you lot."),
                new DialogueLine(Dialogue.players.Golem, "Good Job! But I Will Win Next Round!"),
                new DialogueLine(
                    Dialogue.players.Elf,
                    "For once in your short little life you got lucky."
                ),
                new DialogueLine(Dialogue.players.Dwarf, "For hundred years ain’t short."),
                new DialogueLine(
                    Dialogue.players.Elf,
                    "Compared to five thousand, you’re practically adolescent!"
                )
            }
        );
        var option2 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Dwarf, "…"),
                new DialogueLine(
                    Dialogue.players.Dwarf,
                    "Of course, of course, take your time with your brooding."
                ),
                new DialogueLine(Dialogue.players.Golem, "That Was A Good Play!"),
            }
        );
        var option3 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Dwarf, "’Bout time."),
                new DialogueLine(
                    Dialogue.players.Elf,
                    "Who were we to prevent you from your well-earned, well-deserved victory?"
                ),
                new DialogueLine(Dialogue.players.Golem, "That Was Nice To Say!"),
                new DialogueLine(Dialogue.players.Dwarf, "That’s sarcasm."),
                new DialogueLine(Dialogue.players.Golem, "Oh.")
            }
        );

        List<Dialogue> possibleDialogues = new List<Dialogue>() { option1, option2, option3 };
        Random random = new Random(DateTime.Now.Millisecond);
        return possibleDialogues[random.Next(possibleDialogues.Count)];
    }

    public static Dialogue GetRandomElfWinDialogue()
    {
        var option1 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Elf, "Ha! The sharper mind prevails, gentlemen."),
                new DialogueLine(Dialogue.players.Golem, "Minds Can Be Sharp?"),
                new DialogueLine(Dialogue.players.Dwarf, "’S an expression.")
            }
        );
        var option2 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Elf, "My machinations laid undetected."),
                new DialogueLine(Dialogue.players.Dwarf, "Get over yerself."),
                new DialogueLine(Dialogue.players.Golem, "He Likes Using Big Words."),
                new DialogueLine(
                    Dialogue.players.Dwarf,
                    "He thinks it makes ‘im smarter. It doesn’t."
                )
            }
        );
        var option3 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(
                    Dialogue.players.Elf,
                    "Every closer to claiming the jams for myself. Of cours, yours couldn’t compare to my dear wife’s, ingredients gathered by myself in the far off woods of—"
                ),
                new DialogueLine(
                    Dialogue.players.Dwarf,
                    "At least my wife grows ‘er own ingredients."
                ),
                new DialogueLine(
                    Dialogue.players.Golem,
                    "My Wife Smashes The Fruits In Her Own Core, Her Jam Is The Best."
                ),
                new DialogueLine(Dialogue.players.Elf, "…"),
                new DialogueLine(Dialogue.players.Dwarf, "…")
            }
        );

        List<Dialogue> possibleDialogues = new List<Dialogue>() { option1, option2, option3 };
        Random random = new Random(DateTime.Now.Millisecond);
        return possibleDialogues[random.Next(possibleDialogues.Count)];
    }
}
