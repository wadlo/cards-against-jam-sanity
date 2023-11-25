using Godot;

public partial class DialogueBox : ColorRect
{
    public override void _Process(double delta)
    {
        GetChild<Label>(0).Text = DialogueState.GetCurrentText();
        if (DialogueState.GetCurrentText().Length > 0)
        {
            MakeVisible();
        }
        else
        {
            MakeInvisible();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (
            @event is InputEventMouseButton mouseEvent
            && ((InputEventMouseButton)@event).IsPressed()
        )
        {
            DialogueState.Next();
        }
    }

    public void MakeVisible()
    {
        this.Modulate = new Color("#ffffffff");
    }

    public void MakeInvisible()
    {
        this.Modulate = new Color("#ffffff00");
    }
}
