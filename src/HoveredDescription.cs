using Godot;
using System;

public partial class HoveredDescription : Label
{
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Text =
            CardComponent.GetClosestHoveredCardToMouse(GetViewport())?.config.cardDescription
            ?? CurrentInstructionManager.currentInstruction;
    }
}
