using System.Runtime.CompilerServices;

public class DialogueState
{
    public static Dialogue.players currentSpeaking = Dialogue.players.None;

    public static Dialogue currentDialogue;
    public static int currentDialogueIndex = 0;

    public static void Next()
    {
        if (
            currentDialogue != null
            && currentDialogueIndex < currentDialogue.dialogueLines.Count - 1
        )
        {
            currentDialogueIndex += 1;
        }
        else
        {
            currentDialogue = null;
            currentDialogueIndex = 0;
        }
    }

    public static bool IsFinished()
    {
        return currentDialogue == null;
    }

    public static string GetCurrentText()
    {
        if (!IsFinished())
        {
            return currentDialogue.dialogueLines[currentDialogueIndex].line;
        }
        return "";
    }

    public static Dialogue.players GetCurrentCharacter()
    {
        if (!IsFinished())
        {
            return currentDialogue.dialogueLines[currentDialogueIndex].character;
        }
        return Dialogue.players.None;
    }

    public static void SetDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        currentDialogueIndex = 0;
    }
}
