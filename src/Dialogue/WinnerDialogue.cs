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
        return new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Dwarf, "This is an example winning dialogue"),
                new DialogueLine(Dialogue.players.Elf, "ur an ugly dwarf"),
                new DialogueLine(Dialogue.players.Golem, "beep boop beep")
            }
        );
    }
}
