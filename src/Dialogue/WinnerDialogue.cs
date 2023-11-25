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

    public void Test()
    {
        var option1 = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Dwarf, "Hrm I'm a dwarf"),
                new DialogueLine(Dialogue.players.Elf, "ur an ugly dwarf"),
                new DialogueLine(Dialogue.players.Golem, "beep boop beep")
            }
        );

        new WinnerDialogue(Dialogue.players.Dwarf, new List<Dialogue>() { option1, option1 });
    }
}
