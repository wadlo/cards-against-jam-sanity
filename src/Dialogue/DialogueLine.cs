public class DialogueLine
{
    public Dialogue.players character;
    public string line;

    public DialogueLine(Dialogue.players character, string line)
    {
        this.character = character;
        this.line = line;
    }
}
