using System.Collections.Generic;

public class Dialogue
{
    public enum players
    {
        Dwarf,
        Elf,
        Golem,
    }

    public Dialogue(List<DialogueLine> dialogueLines) { }

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
