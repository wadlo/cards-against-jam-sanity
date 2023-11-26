using System.Runtime.CompilerServices;
using Godot;

public partial class DialogueState : Node
{
	[Export]
	public Node2D dwarfCameraCenter;

	[Export]
	public Node2D elfCameraCenter;

	[Export]
	public Node2D golemCameraCenter;

	[Export]
	public Camera2D camera;

	[Export]
	public float zoomedOutZoom = 0.63f;

	[Export]
	public float zoomedInZoom = 1.0f;

	public static Dialogue.players currentSpeaking = Dialogue.players.None;

	public static Dialogue currentDialogue;
	public static int currentDialogueIndex = 0;

	Vector2 startCameraPosition;

	Tween positionTween;
	Tween tween;

	public override void _Ready()
	{
		startCameraPosition = camera.GlobalPosition;
	}

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
			bool characterStillExists = false;
			foreach (PlayerState playerState in RoundController.instance.computers)
			{
				if (
					currentDialogue != null
					&& currentDialogue.dialogueLines[currentDialogueIndex].character
						== playerState.player
				)
				{
					characterStillExists = true;
				}
			}
			if (!characterStillExists)
			{
				return "...";
			}
			return currentDialogue.dialogueLines[currentDialogueIndex].line;
		}
		return "";
	}

	public override void _Process(double delta)
	{
		Vector2 cameraPosition = startCameraPosition;
		float cameraScale = zoomedInZoom;

		if (GetCurrentCharacter() == Dialogue.players.None)
		{
			cameraScale = zoomedOutZoom;
		}
		else
		{
			cameraScale = zoomedInZoom;
		}

		if (GetCurrentCharacter() == Dialogue.players.Dwarf)
		{
			cameraPosition = dwarfCameraCenter.GlobalPosition;
		}
		if (GetCurrentCharacter() == Dialogue.players.Elf)
		{
			cameraPosition = elfCameraCenter.GlobalPosition;
		}
		if (GetCurrentCharacter() == Dialogue.players.Golem)
		{
			cameraPosition = golemCameraCenter.GlobalPosition;
		}
		tween = GetTree().CreateTween();

		tween.TweenProperty(camera, "zoom", new Vector2(cameraScale, cameraScale), 0.1f);
		tween.TweenProperty(camera, "global_position", cameraPosition, 0.1f);
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
		if (currentDialogue.dialogueLines.Count == 0)
		{
			currentDialogue = null;
		}
	}
}
