using System.Collections.Generic;

public class AngerBasedDialogue
{
    int elfAnger;
    int dwarfAnger;
    int golemAnger;
    Dialogue dialogue;

    public AngerBasedDialogue(int elfAnger, int dwarfAnger, int golemAnger, Dialogue dialogue)
    {
        this.elfAnger = elfAnger;
        this.dwarfAnger = dwarfAnger;
        this.golemAnger = golemAnger;
        this.dialogue = dialogue;
    }

    public static Dialogue GetDialog()
    {
        int elfAnger = 0;
        int dwarfAnger = 0;
        int golemAnger = 0;
        foreach (PlayerState playerState in RoundController.instance.computers)
        {
            if (playerState.player == Dialogue.players.Dwarf)
            {
                dwarfAnger = playerState.timesOffended;
            }
            if (playerState.player == Dialogue.players.Elf)
            {
                elfAnger = playerState.timesOffended;
            }
            if (playerState.player == Dialogue.players.Golem)
            {
                golemAnger = playerState.timesOffended;
            }
        }

        List<AngerBasedDialogue> angerBasedDialogues = new List<AngerBasedDialogue>()
        {
            // Dialogue option start
            new AngerBasedDialogue(
                0, // elf anger
                1, // dwarf anger
                0, // golem
                new Dialogue(
                    new List<DialogueLine>()
                    {
                        new DialogueLine(Dialogue.players.Dwarf, "I'm an angry dwarf"),
                        new DialogueLine(Dialogue.players.Elf, "rlly? I'm not mad"),
                        new DialogueLine(Dialogue.players.Golem, ":)")
                    }
                )
            ),
            // Dialogue option start
            new AngerBasedDialogue(
                0, // elf anger
                1, // dwarf anger
                2, // golem
                new Dialogue(
                    new List<DialogueLine>()
                    {
                        new DialogueLine(Dialogue.players.Golem, ":()"),
                        new DialogueLine(Dialogue.players.Dwarf, ":/")
                    }
                )
            ),
        };

        foreach (AngerBasedDialogue option in angerBasedDialogues)
        {
            if (
                option.elfAnger == elfAnger
                && option.dwarfAnger == dwarfAnger
                && option.golemAnger == golemAnger
            )
            {
                return option.dialogue;
            }
        }

        return new Dialogue(
            new List<DialogueLine>()
            {
                new DialogueLine(Dialogue.players.Golem, "Error Not Implemented"),
                new DialogueLine(Dialogue.players.Golem, ":/")
            }
        );
    }
}
