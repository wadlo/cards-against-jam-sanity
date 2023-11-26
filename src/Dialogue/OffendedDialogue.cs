using System;
using System.Collections.Generic;

public class OffendedDialogue
{
    Dialogue.players offendedPlayer;
    List<Dialogue> possibleDialogues;

    public OffendedDialogue(Dialogue.players offendedPlayer, List<Dialogue> possibleDialogues) { }

    public static Dialogue GetRandomDialogueForOffendedPlayer(
        Dialogue.players offendedPlayer,
        int angerLevel
    )
    {
        List<Dialogue> possibleDialogues = new List<Dialogue>()
        {
            new Dialogue(
                new List<DialogueLine>()
                {
                    new DialogueLine(
                        Dialogue.players.Elf,
                        "Those devs didn't finish the dialogue, did they?"
                    ),
                    new DialogueLine(Dialogue.players.Dwarf, "Obviously they didn't"),
                    new DialogueLine(Dialogue.players.Golem, ":/")
                }
            )
        };

        if (offendedPlayer == Dialogue.players.Elf)
        {
            if (angerLevel == 1)
            {
                possibleDialogues = new List<Dialogue>()
                {
                    new Dialogue(
                        new List<DialogueLine>()
                        {
                            new DialogueLine(
                                Dialogue.players.Elf,
                                "At least someone at this table knows how to play nice."
                            ),
                        }
                    ),
                    new Dialogue(
                        new List<DialogueLine>()
                        {
                            new DialogueLine(Dialogue.players.Elf, "Interesting play."),
                        }
                    ),
                    new Dialogue(
                        new List<DialogueLine>()
                        {
                            new DialogueLine(
                                Dialogue.players.Elf,
                                "Ah, that is quite the decision…"
                            ),
                        }
                    ),
                };
            }

            if (angerLevel == 2)
            {
                possibleDialogues = new List<Dialogue>()
                {
                    new Dialogue(
                        new List<DialogueLine>()
                        {
                            new DialogueLine(Dialogue.players.Elf, "No, no thank you!"),
                        }
                    ),
                    new Dialogue(
                        new List<DialogueLine>()
                        {
                            new DialogueLine(Dialogue.players.Elf, "Shoo!"),
                        }
                    ),
                    new Dialogue(
                        new List<DialogueLine>()
                        {
                            new DialogueLine(
                                Dialogue.players.Elf,
                                "Really testing my patience, aren’t you?"
                            ),
                        }
                    ),
                };
            }

            if (angerLevel == 3)
            {
                possibleDialogues = new List<Dialogue>()
                {
                    new Dialogue(
                        new List<DialogueLine>()
                        {
                            new DialogueLine(
                                Dialogue.players.Elf,
                                "You are living proof that mankind is selfish."
                            ),
                        }
                    ),
                    new Dialogue(
                        new List<DialogueLine>()
                        {
                            new DialogueLine(Dialogue.players.Elf, "Don’t touch that!"),
                        }
                    ),
                    new Dialogue(
                        new List<DialogueLine>()
                        {
                            new DialogueLine(
                                Dialogue.players.Elf,
                                "Really? You are a foul creature."
                            ),
                        }
                    ),
                };
            }
        }

        Random random = new Random(DateTime.Now.Millisecond);

        int index = random.Next(possibleDialogues.Count);
        return possibleDialogues[index];
    }
}
