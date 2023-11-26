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
                new DialogueLine(Dialogue.players.Elf, "player won"),
                new DialogueLine(Dialogue.players.Golem, "player?"),
                new DialogueLine(Dialogue.players.Dwarf, "’playr.")
            }
        );
        var option2 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Elf, "player won"),
                new DialogueLine(Dialogue.players.Golem, "player?"),
                new DialogueLine(Dialogue.players.Dwarf, "’playr."),
                new DialogueLine(
                    Dialogue.players.Dwarf,
                    "He thinks it makes ‘im smarter. It doesn’t."
                )
            }
        );
        var option3 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Elf, "player won"),
                new DialogueLine(Dialogue.players.Golem, "player?"),
                new DialogueLine(Dialogue.players.Dwarf, "’playr.")
            }
        );

        List<Dialogue> possibleDialogues = new List<Dialogue>() { option1, option2, option3 };
        Random random = new Random(new System.DateTime().Millisecond);
        return possibleDialogues[random.Next(possibleDialogues.Count)];
    }

    public static Dialogue GetRandomGolemWinDialogue()
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
        Random random = new Random(new System.DateTime().Millisecond);
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
        Random random = new Random(new System.DateTime().Millisecond);
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
        Random random = new Random(new System.DateTime().Millisecond);
        return possibleDialogues[random.Next(possibleDialogues.Count)];
    }
}
