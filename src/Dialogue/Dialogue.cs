using System.Collections.Generic;

public class Dialogue
{
    public enum players
    {
        Dwarf,
        Elf,
        Golem,
        None,
    }

    public List<DialogueLine> dialogueLines;

    public Dialogue(List<DialogueLine> dialogueLines)
    {
        this.dialogueLines = dialogueLines;
    }

    public void test()
    {
        var test = new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(players.Dwarf, "Hrrm, I'm a dwarf"),
                new DialogueLine(players.Dwarf, "Hrrm, I'm a dwarf")
            }
        );
    }
}
